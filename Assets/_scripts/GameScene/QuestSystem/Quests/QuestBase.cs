using System;
using UnityEngine;

public class QuestBase : MonoBehaviour
{
    public event Action OnQuestCompleted;
    public static event Action OnStaticQuestComplete;
    public bool IsActive;

    protected void QuestCompleted()
    {
        //Debug.Log("Quest completed");
        OnQuestCompleted?.Invoke();
        OnStaticQuestComplete?.Invoke();
    }
   
    public virtual void OnUI() 
    {
        IsActive = true;
    }
    public virtual void OffUI() 
    {
        IsActive = false;
    }
}
