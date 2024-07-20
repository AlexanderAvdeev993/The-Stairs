using System;
using UnityEngine;

public class UIMenuSceneRootBinder : MonoBehaviour
{
    public event Action GoToGameSceneButtonClicked;

    public void HandleGoToGameSceneButtonClick()
    {
        GoToGameSceneButtonClicked?.Invoke();
    }
}
