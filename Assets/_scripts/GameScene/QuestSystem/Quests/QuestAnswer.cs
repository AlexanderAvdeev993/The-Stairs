using System;

[Serializable]
public class QuestAnswer 
{
    public QuestType _questType;

    public bool[] ButtonQuestAnswer = new bool[16];
    public int IntQuest;
}
