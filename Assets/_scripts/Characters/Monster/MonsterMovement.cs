using UnityEngine;
using UnityEngine.AI;

public class MonsterMovement : MonoBehaviour
{
    private Transform _playerTransform;  
    private NavMeshAgent navMeshAgent;

    public void Init(Transform playerTransform)
    {
        _playerTransform = playerTransform;
    }

    void Start()
    {       
        navMeshAgent = GetComponent<NavMeshAgent>();   
    }

    void Update()
    {
        if (_playerTransform != null)
        {            
            navMeshAgent.SetDestination(_playerTransform.position);          
        }
    }
}