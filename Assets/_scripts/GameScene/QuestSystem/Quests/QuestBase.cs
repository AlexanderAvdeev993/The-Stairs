using System;
using UnityEngine;

public class QuestBase : MonoBehaviour
{
    public event Action OnEventCompleted;
    protected void QuestCompleted()
    {
        Debug.Log("Quest completed");
        OnEventCompleted?.Invoke();
    }
}
