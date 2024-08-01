using TMPro;
using UnityEngine;

public class MathQuest : QuestBase
{
    [SerializeField] private TextMeshProUGUI _UIText;
    [SerializeField] private int _maxCountValue;
    [SerializeField] private string _currentValue;
    [SerializeField] private int _answer;
    [SerializeField] private GameObject _UIItems;

    public void Init(int answer)
    {
        _answer = answer;
    }
    private void Awake()
    {
        OffUI();
    }

    public void SetValue(string value)
    {
        if (_currentValue.Length <= _maxCountValue)
        {
            _currentValue += value;
            UpdateUI();
        }     
    }
    
    public void DeleteValue()
    {
        if (_currentValue.Length > 0)
        {
            _currentValue = _currentValue.Substring(0, _currentValue.Length - 1);
            UpdateUI();
        }
    }
    public void CheckComplete()
    {
        if (_answer == int.Parse(_currentValue))
        {
            QuestCompleted();
        }
    }
    private void UpdateUI()
    {
        _UIText.text = _currentValue;
    }

    public override void OffUI()
    {
        base.OffUI();
        _UIItems.SetActive(false);
    }
    public override void OnUI()
    {
        base.OnUI();
        _UIItems.SetActive(true);
    }
}
