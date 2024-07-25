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
        //_buttonQuest.Init(_quests[0].ButtonQuestAnswer);
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


   public QuestBase GetQuest(int id)
   {
       return _buttonQuest;
   }


    private List<QuestAnswer> QuestAnswers()
    {
        var questAnswers = Resources.Load<QuestSO>("QuestSO").GetQuestAnswer();
        return questAnswers;
    }
}
