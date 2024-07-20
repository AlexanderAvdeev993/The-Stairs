using System;
using UnityEngine;

public class ChunkTrigger : MonoBehaviour
{
    public static event Action OnTriggerChunkChange;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {  
            OnTriggerChunkChange?.Invoke();
            gameObject.SetActive(false);
        }
    }
}
