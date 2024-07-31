using UnityEngine;

public class EnterQuestButton : MonoBehaviour, IInteractable
{
    [SerializeField] private string _description;
    [SerializeField] private Renderer _display;
    [SerializeField] private Color _ClosedColor;
    [SerializeField] private Color _OpenColor;
    [SerializeField] private Collider _collider;

   /* private void Awake()
    {
        _collider = GetComponent<Collider>();
    }*/
    public string GetDescription()
    {
        return _description;
    }

    public void Interact()
    {
        //Debug.Log("interact");
    }
    public void QuestButtonON()
    {
        _display.material.color = _OpenColor;
        _collider.enabled = false;
    }
    public void QuestButtonOFF()
    {
        _display.material.color = _ClosedColor;
        _collider.enabled = true;
    }
}
