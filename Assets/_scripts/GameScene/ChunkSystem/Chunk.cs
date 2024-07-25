using UnityEngine;

public class Chunk : MonoBehaviour
{
    [SerializeField] private GameObject _chunkTrigger;
    private DoorController _doorController;
    private QuestBase _quest;

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
    }

    private void SubscribeToCompleteQuest()
    {
        _quest.OnQuestCompleted += _doorController.OpenDoor;
    }

    private void UnsubscribeToCompleteQuest()
    {
        if (_quest != null)
        {
            _quest.OnQuestCompleted -= _doorController.OpenDoor;
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
    }
    public void CloseDoor()
    {
        _doorController.CloseDoor();
    }
}
