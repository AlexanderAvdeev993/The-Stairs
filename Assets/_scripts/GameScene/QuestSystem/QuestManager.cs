using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    [SerializeField] private ButtonQuest _buttonQuest;
    
    private List<QuestAnswer> _quests;
    private QuestBase _currentQuest;
    

    private void Start()
    {         
        _quests = LoadQuestAnswers();           
    }

    private void OnEnable()
    {
        PlayerInteraction.OnQuestUIActive += OnQuestUI;
        QuestBase.OnStaticQuestComplete += OffQuestUI;
    }
    private void OnDisable()
    {
        PlayerInteraction.OnQuestUIActive -= OnQuestUI;
        QuestBase.OnStaticQuestComplete -= OffQuestUI;
    }

    private void OnQuestUI()
    {
        //Debug.Log("UI on");       
        if (_currentQuest.IsActive == false)
        {
            _currentQuest.OnUI();
        }
        else
        {
            _currentQuest.OffUI();
        }
    }
    private void OffQuestUI()
    {               
         _currentQuest.OffUI();
    }

    public void LoadQuest(int levelIndex, Chunk currentChunk, Chunk previousChunk)
    {       
        switch (_quests[levelIndex].QuestType)
        {
            case QuestType.ButtonQuest:             
                _buttonQuest.Init(_quests[levelIndex].ButtonQuestAnswer);
                _currentQuest = _buttonQuest;

                var chunkSpriteHintPoint = previousChunk.GetSpriteHintPoint();
                chunkSpriteHintPoint.sprite = _quests[levelIndex].SpriteHint;

                currentChunk.InitQuest(_currentQuest);
                break;                 
        }                           
    }

    private List<QuestAnswer> LoadQuestAnswers()
    {
        var questAnswers = Resources.Load<QuestSO>("QuestSO").GetQuestAnswer();
        return questAnswers;
    }
}
