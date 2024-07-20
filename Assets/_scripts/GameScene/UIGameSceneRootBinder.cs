using System;
using UnityEngine;
using TMPro;

public class UIGameSceneRootBinder : MonoBehaviour
{
    public event Action GoToMenuSceneButtonClicked;
    [SerializeField] private TextMeshProUGUI _interactableText;

    public void HandleGoToMenuSceneButtonClick()
    {
        GoToMenuSceneButtonClicked?.Invoke();
    }

    private void OnEnable()
    {
        PlayerInteraction.OnActiveDescription += InteractableText;
    }
    private void OnDisable()
    {
        PlayerInteraction.OnActiveDescription -= InteractableText;
    }

    public void InteractableText(bool OnText , string text)
    {
        if (OnText)
        {
            _interactableText.gameObject.SetActive(true);
            _interactableText.text = text;
        }
        else
        {
            _interactableText.gameObject.SetActive(false);
        }      
    }
}
