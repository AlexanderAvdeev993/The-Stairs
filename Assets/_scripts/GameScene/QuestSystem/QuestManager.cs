using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    [SerializeField] private ButtonQuest _buttonQuest;
    private List<QuestAnswer> _quests;
    private QuestBase _currentQuest;

    private void Start()
    {
        _quests = QuestAnswers();     
    }

    public void LoadQuest(int levelIndex, Chunk currentChunk)
    {
        switch (_quests[levelIndex].QuestType)
        {
            case QuestType.ButtonQuest:
                _buttonQuest.gameObject.SetActive(true);
                _buttonQuest.Init(_quests[levelIndex].ButtonQuestAnswer);
                _currentQuest = _buttonQuest;

                currentChunk.InitQuest(_currentQuest);
                break;                 
        }                           
    }

    private List<QuestAnswer> QuestAnswers()
    {
        var questAnswers = Resources.Load<QuestSO>("QuestSO").GetQuestAnswer();
        return questAnswers;
    }
}
