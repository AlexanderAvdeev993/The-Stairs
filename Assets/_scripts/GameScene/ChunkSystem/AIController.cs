using Unity.AI.Navigation;
using UnityEngine;

public class AIController : MonoBehaviour
{
    private NavMeshSurface navMeshSurface;

    void Awake()
    {
        navMeshSurface = GetComponent<NavMeshSurface>();
    }

    public void UpdateNavMesh()
    {
        navMeshSurface.BuildNavMesh();
    }
}
