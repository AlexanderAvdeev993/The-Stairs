using UnityEngine;

public class EnterQuestButton : MonoBehaviour, IInteractable
{
    [SerializeField] private string _description;
    public string GetDescription()
    {
        return _description;
    }

    public void Interact()
    {
        Debug.Log("interact");
    }
}
