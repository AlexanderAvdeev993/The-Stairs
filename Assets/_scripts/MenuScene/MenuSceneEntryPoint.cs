using System;
using UnityEngine;

public class MenuSceneEntryPoint : MonoBehaviour
{
    public event Action GoToGameSceneRequested;

    [SerializeField] private UIMenuSceneRootBinder _sceneUIRootPrefab;

    public void Run(UIRootView uIRootView)
    {
        var uiScene = Instantiate(_sceneUIRootPrefab);
        uIRootView.AttachSceneUI(uiScene.gameObject);

        uiScene.GoToGameSceneButtonClicked += () =>
        {
            GoToGameSceneRequested?.Invoke();
        };

        Debug.Log("GameSceneEntryPoint");
    }
}
