using System.Collections.Generic;
using UnityEngine;

public class Hints : MonoBehaviour
{
    [SerializeField] private List<SpriteRenderer> _hints;

    public SpriteRenderer GetRandomSprite()
    {
        OffAllHints();
        var randomCount = Random.Range(0, _hints.Count);
        return _hints[randomCount];
    }
    private void OffAllHints()
    {
        foreach (var hint in _hints)
        {
            hint.sprite = null; 
        }

    }
}
