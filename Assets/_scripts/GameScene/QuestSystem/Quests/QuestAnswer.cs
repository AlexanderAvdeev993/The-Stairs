using System;

[Serializable]
public class QuestAnswer 
{
    public QuestType QuestType;
    public bool[] ButtonQuestAnswer = new bool[16];    
    public int IntQuest;   
}
