using System;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneEntryPoint : MonoBehaviour
{
    public event Action GoToMenuSceneRequested;

    [SerializeField] private UIGameSceneRootBinder _sceneUIRootPrefab;
    [SerializeField] private ChunkManager _chunkManager;
    [SerializeField] private PlayerController _playerPrefab;
    [SerializeField] private MonsterMovement _monsterPrefab;

    [SerializeField] private Transform _monsterSpawnPoint;

    public void Run(UIRootView uIRootView)
    {
        var uiScene = Instantiate(_sceneUIRootPrefab);       
        uIRootView.AttachSceneUI(uiScene.gameObject);

        //Instantiate(_chunkManager);
        PlayerController playerInstance = Instantiate(_playerPrefab);
       
        //MonsterMovement monsterInstance = Instantiate(_monsterPrefab, _monsterSpawnPoint);
        //monsterInstance.Init(playerInstance.transform);

        uiScene.GoToMenuSceneButtonClicked += () =>
        {
            GoToMenuSceneRequested?.Invoke();
        };
        Debug.Log("GameSceneEntryPoint");
    }

    private List<QuestAnswer> QuestAnswers()
    {
        var questAnswers = Resources.Load<QuestSO>("QuestSO").GetQuestAnswer();
        return questAnswers;
    }
}
