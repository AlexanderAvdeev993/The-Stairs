using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class UIButton : MonoBehaviour
{
    public static event Action OnButtonClick;

    [SerializeField] private Color activeColor = Color.red;
    public bool IsActive { get; private set; }
    private Button _button;
    private Image _image;
    private Color _originalColor;
    

    private void Start()
    {
        _button = GetComponent<Button>();
        _image = GetComponent<Image>();
        if (_image != null)       
            _originalColor = _image.color;     
        if (_button != null)      
            _button.onClick.AddListener(ButtonClick);       
    }

    private void ButtonClick()
    {
        IsActive = !IsActive;
        if (_image != null)
        {
            _image.color = IsActive ? activeColor : _originalColor;
        }
        OnButtonClick?.Invoke();
    }
    public void SwitchButtonActive()
    {
        IsActive = !IsActive;
        if (_image != null)
        {
            _image.color = IsActive ? activeColor : _originalColor;
        }
    }
}
