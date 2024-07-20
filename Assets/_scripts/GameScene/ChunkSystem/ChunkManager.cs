using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(AIController))]
public class ChunkManager : MonoBehaviour
{
    [SerializeField] private GameObject _chunkPrefab;
    [SerializeField] private float _chunkHeight = 12f;
    [SerializeField] private int _totalChunks = 3;
    private List<Transform> _chunks = new List<Transform>();
    private int _�hunkIndex;
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
            newChunk.GetComponent<Chunk>().InitQuest(_questManager.GetQuest(_�hunkIndex));          // ����� �����
            _chunks.Add(newChunk.transform); 
            _�hunkIndex = i;
        }
        _chunks[0].GetComponentInChildren<Chunk>().TriggerOff();
        _chunks[1].GetComponentInChildren<Chunk>().TriggerOff();
        _�hunkIndex = _totalChunks;
       
        _aiController.UpdateNavMesh();
    }

    private void MoveChunk()
    {
        Transform chunkToMove = _chunks[0];
        _chunks.RemoveAt(0);
        chunkToMove.position = new Vector3(0, _chunkHeight * _�hunkIndex, 0);
        Chunk chunk = chunkToMove.GetComponent<Chunk>();
        chunk.TriggerOn();
        // chunk.Init();          // ����� �����


        _chunks.Add(chunkToMove);
        _�hunkIndex++;

        _aiController.UpdateNavMesh();
    }

 
}
