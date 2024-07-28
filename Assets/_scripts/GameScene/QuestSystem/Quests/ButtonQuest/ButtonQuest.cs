using System.Collections.Generic;
using UnityEngine;

public class ButtonQuest : QuestBase
{
    [SerializeField] private List<UIButton> _buttons;
    [SerializeField] private bool[] _requiredButtons = new bool[16];

    private void Awake()
    {
        OffUI();
    }

    public void Init(bool[] requiredButtons)
    {
        _requiredButtons = requiredButtons;
    }

    public override void OnUI()
    {   
        base.OnUI();
        foreach (var button in _buttons)
        {
            button.gameObject.SetActive(true);
        }
    }
    public override void OffUI()
    {   
        base.OffUI();
        foreach (var button in _buttons)
        {
            button.gameObject.SetActive(false);
        }
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

        foreach (var button in _buttons)
        {
            if (button.IsActive)
            {
                button.SwitchButtonActive();
            }
        }

        QuestCompleted();
        OffUI();
    }
}
