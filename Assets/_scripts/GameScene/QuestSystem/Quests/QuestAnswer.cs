using System;
using UnityEngine;

[Serializable]
public class QuestAnswer 
{
    public QuestType QuestType;
    public bool[] ButtonQuestAnswer = new bool[16];
    public Sprite SpriteHint;
    public int IntQuest;   
}
