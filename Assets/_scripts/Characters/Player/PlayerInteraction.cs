using System;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public static event Action<bool ,string> OnActiveDescription;

    private IInteractable _currentInteractable;

    private void OnTriggerEnter(Collider other)
    {    
        IInteractable interactable = other.GetComponent<IInteractable>();
        if (interactable != null)
        {          
            _currentInteractable = interactable;
            _currentInteractable.Interact();
            OnActiveDescription?.Invoke(true, _currentInteractable.GetDescription());
        }
    }
    private void OnTriggerExit(Collider other)
    {
        IInteractable interactable = other.GetComponent<IInteractable>();
        if(interactable != null)
        {
            OnActiveDescription?.Invoke(false, null);
        }
    }
}
