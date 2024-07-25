using System.Collections.Generic;
using UnityEngine;

public class ButtonQuest : QuestBase
{
    [SerializeField] private List<UIButton> _buttons;
    [SerializeField] private bool[] _requiredButtons = new bool[16]; /*=
    {
        true,false,false,true,
        false,false,false,false,
        false,false,false,false,
        true,false,false,true
    };*/

    public void Init(bool[] requiredButtons)
    {
        _requiredButtons = requiredButtons;
    }

    private void OnEnable()
    {
        UIButton.OnButtonClick += CheckQuestCompleting;
    }
    private void OnDisable()
    {
        UIButton.OnButtonClick -= CheckQuestCompleting;
    }

    private void CheckQuestCompleting()
    {     
        for (int i = 0; i < _buttons.Count; i++)
        {
            if (_buttons[i].IsActive != _requiredButtons[i])
                return;
        }
        QuestCompleted();
    }
   /* private void QuestCompleted()
    {
        Debug.Log("Quest completed");
    }*/
}
