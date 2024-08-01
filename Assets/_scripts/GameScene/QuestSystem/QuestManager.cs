using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    [SerializeField] private ButtonQuest _buttonQuest;
    [SerializeField] private MathQuest _mathQuest;
    
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
        if (levelIndex < 0 || levelIndex >= _quests.Count)
        {
            Debug.LogError("Invalid levelIndex provided.");
            return;
        }

        QuestAnswer questAnswer = _quests[levelIndex];

        switch (_quests[levelIndex].QuestType)
        {
            case QuestType.ButtonQuest:             
                _buttonQuest.Init(questAnswer.ButtonQuestAnswer);
                _currentQuest = _buttonQuest;

                //var chunkSpriteHintPoint = previousChunk.GetSpriteHintPoint();
                //chunkSpriteHintPoint.sprite = _quests[levelIndex].SpriteHint;

                //currentChunk.InitQuest(_currentQuest);
                break;   
                
            case QuestType.MathQuest:
                _mathQuest.Init(questAnswer.MathQuestAnswer);
                _currentQuest = _mathQuest;

                //var chunkSpriteHintPoint = previousChunk.GetSpriteHintPoint();
                //chunkSpriteHintPoint.sprite = _quests[levelIndex].SpriteHint;

                //currentChunk.InitQuest(_currentQuest);
                break;                           
        }
        if (previousChunk != null)
        {
            var chunkSpriteHintPoint = previousChunk.GetSpriteHintPoint();
            if (chunkSpriteHintPoint != null)
                chunkSpriteHintPoint.sprite = questAnswer.SpriteHint;
        }

        if (currentChunk != null)
            currentChunk.InitQuest(_currentQuest);
    }

    private List<QuestAnswer> LoadQuestAnswers()
    {
        var questAnswers = Resources.Load<QuestSO>("QuestSO").GetQuestAnswer();
        return questAnswers;
    }
}
