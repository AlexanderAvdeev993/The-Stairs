using UnityEngine;

public class Chunk : MonoBehaviour
{
    [SerializeField] private GameObject _chunkTrigger;
    private DoorController _doorController;
    private QuestBase _quest;

    public GameObject getChunkTrigger() => _chunkTrigger;

    public void InitQuest(QuestBase quest)
    {
        _quest = quest;
        UnsubscribeToCompleteQuest();
        
        SubscribeToCompleteQuest();
    }

    private void Awake()
    {
        _doorController = GetComponentInChildren<DoorController>();
    }

    private void SubscribeToCompleteQuest()
    {
        _quest.OnEventCompleted += _doorController.OpenDoor;
    }
    private void UnsubscribeToCompleteQuest()
    {   
        
        _quest.OnEventCompleted -= _doorController.OpenDoor;
        
    }
    public void TriggerOff()
    {
        _chunkTrigger.SetActive(false);
    }
    public void TriggerOn()
    {
        _chunkTrigger.SetActive(true);
    }
}
