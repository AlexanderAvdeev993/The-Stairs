using UnityEngine;

public class Chunk : MonoBehaviour
{
    [SerializeField] private GameObject _chunkTrigger;
    private DoorController _doorController;
    private QuestBase _quest;
    private Hints _hints;
    private EnterQuestButton _enterQuestButton;

    public int _chunkID;   // test

    public GameObject GetChunkTrigger() => _chunkTrigger;

    public void InitQuest(QuestBase newQuest)
    {
        UnsubscribeToCompleteQuest();
        _quest = newQuest;
        SubscribeToCompleteQuest();
    }

    private void Awake()
    {
        _doorController = GetComponentInChildren<DoorController>();
        _hints = GetComponentInChildren<Hints>();
        _enterQuestButton = GetComponentInChildren<EnterQuestButton>();
    }
    public SpriteRenderer GetSpriteHintPoint()
    {
        return _hints.GetRandomSprite();
    }

    private void SubscribeToCompleteQuest()
    {
        _quest.OnQuestCompleted += OpenDoor;      
    }

    private void UnsubscribeToCompleteQuest()
    {
        if (_quest != null)
        {
            _quest.OnQuestCompleted -= OpenDoor;           
        }
    }

    public void TriggerOff()
    {
        _chunkTrigger.SetActive(false);
    }

    public void TriggerOn()
    {
        _chunkTrigger.SetActive(true);
    }
    public void OpenDoor()
    {
        _doorController.OpenDoor(); 
        _enterQuestButton.QuestButtonON();
        if (_quest != null)
        {
            _quest.OnQuestCompleted -= OpenDoor;        
        }
    }
    public void CloseDoor()
    {
        _doorController.CloseDoor();
        _enterQuestButton.QuestButtonOFF();
    }
}
