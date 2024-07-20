using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestSO", menuName = "QuestSO")]
public class QuestSO : ScriptableObject
{  
    [SerializeField] private List<QuestBase>  _questsList;
    [SerializeField] private List<QuestAnswer> _answer;
}
