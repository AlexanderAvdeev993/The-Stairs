using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(AIController))]
public class ChunkManager : MonoBehaviour
{
    [SerializeField] private GameObject _chunkPrefab;
    [SerializeField] private float _chunkHeight = 12f;
    [SerializeField] private int _totalChunks = 3;
    private List<Chunk> _chunks = new List<Chunk>();
    private int _ñhunkIndex = 0;
    private AIController _aiController;
    private QuestManager _questManager;
    
    public void Init(QuestManager questManager)
    {
        _questManager = questManager; 
    }

    private void Start()
    {
        _aiController = GetComponent<AIController>();
        InitializeChunks();      
    }

    private void OnEnable()
    {
        ChunkTrigger.OnTriggerChunkChange += MoveChunk;
    }
    private void OnDisable()
    {
        ChunkTrigger.OnTriggerChunkChange -= MoveChunk;
    }

    private void InitializeChunks()
    {
        for (int i = 0; i < _totalChunks; i++)
        {
            var newChunk = Instantiate(_chunkPrefab, new Vector3(0, _chunkHeight * i, 0), Quaternion.identity);    
            newChunk.transform.parent = transform;
            
            _chunks.Add(newChunk.GetComponent<Chunk>()); 
            _ñhunkIndex = i;
        }
        _questManager.LoadQuest(0, _chunks[2]);  

        _chunks[0].TriggerOff();
        _chunks[0].OpenDoor();
        _chunks[1].TriggerOff();
        _chunks[1].OpenDoor();

        _ñhunkIndex = _totalChunks;       
        _aiController.UpdateNavMesh();
    }

    private void MoveChunk()
    {
        Transform chunkToMove = _chunks[0].transform;
        _chunks.RemoveAt(0);
        chunkToMove.position = new Vector3(0, _chunkHeight * _ñhunkIndex, 0);
        Chunk chunk = chunkToMove.GetComponent<Chunk>();
        chunk.TriggerOn();
        chunk.CloseDoor();
        
        _chunks.Add(chunkToMove.GetComponent<Chunk>());
        _ñhunkIndex++;

        _questManager.LoadQuest(_ñhunkIndex - _chunks.Count,_chunks[2]);

        _aiController.UpdateNavMesh();
    }

 
}
