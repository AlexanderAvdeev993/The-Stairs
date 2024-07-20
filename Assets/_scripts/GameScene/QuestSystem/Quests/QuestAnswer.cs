using System;
using System.Collections.Generic;

[Serializable]
public class QuestAnswer 
{
    public QuestType _questType;

    public bool[] ButtonQuest = new bool[16];
    public int IntQuest;
}
