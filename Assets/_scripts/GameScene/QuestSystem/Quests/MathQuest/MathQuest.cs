using TMPro;
using UnityEngine;

public class MathQuest : QuestBase
{
    [SerializeField] private TextMeshProUGUI _UIText;
    [SerializeField] private int _maxCountValue;   
    [SerializeField] private int _answer;
    [SerializeField] private GameObject _UIItems;
    private string _currentValue;

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
    private void ClearCurrentValue()
    {
        _currentValue = string.Empty;
        UpdateUI();
    }
    public void CheckComplete()
    {
        int parsValue;
        bool IsParseValue = int.TryParse(_currentValue, out parsValue);

        if(!string.IsNullOrEmpty(_currentValue))
        {
            if(IsParseValue && _answer == parsValue)          
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
        ClearCurrentValue();
        _UIItems.SetActive(false);       
    }
    public override void OnUI()
    {
        base.OnUI();
        _UIItems.SetActive(true);
    }
}
