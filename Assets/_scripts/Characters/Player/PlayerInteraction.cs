using System;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public static event Action<bool ,string> OnActiveDescription;
    public static event Action OnQuestUIActive;
    private bool _mActive = false;
    private PlayerController _playerController;
    private IInteractable _currentInteractable;

    private void Awake()
    {
        _playerController = GetComponent<PlayerController>();
    }

    private void OnEnable()
    {
        ButtonQuest.OnStaticQuestComplete += OffQuestMode;
    }
    private void OnDisable()
    {
        ButtonQuest.OnStaticQuestComplete -= OffQuestMode;
    }

    private void OnTriggerEnter(Collider other)
    {    
        IInteractable interactable = other.GetComponent<IInteractable>();
        if (interactable != null)
        {          
            _currentInteractable = interactable;
            _currentInteractable.Interact();
            OnActiveDescription?.Invoke(true, _currentInteractable.GetDescription());

            _mActive = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        IInteractable interactable = other.GetComponent<IInteractable>();
        if(interactable != null)
        {
            OnActiveDescription?.Invoke(false, null);         
            _mActive = false;
        }
    }
    private void OffQuestMode()
    {
        _playerController.OffQuestMode();
    }

    private void Update()
    {
        if (_mActive && Input.GetKeyDown(KeyCode.E))
        {         
            _playerController.SwitchQuestMode();
            OnActiveDescription?.Invoke(false, null);
            OnQuestUIActive?.Invoke();
        }    
    }
}
