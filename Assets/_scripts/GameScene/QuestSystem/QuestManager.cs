using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    [SerializeField] private ButtonQuest _buttonQuest;
    private List<QuestAnswer> _quests;

    private void Start()
    {
        _quests = QuestAnswers();
        _buttonQuest.Init(_quests[0].ButtonQuestAnswer);
    }




    /*public QuestAnswer GetQuest(int id)
    {
        return _quests[id];
    }*/

    private List<QuestAnswer> QuestAnswers()
    {
        var questAnswers = Resources.Load<QuestSO>("QuestSO").GetQuestAnswer();
        return questAnswers;
    }
}
