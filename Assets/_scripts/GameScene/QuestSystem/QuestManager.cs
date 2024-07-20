using System.Collections.Generic;

public class QuestManager
{
    private List<QuestBase> _quests;


    public void Init(List<QuestBase> quests)
    {
        _quests = quests;
    }

    public QuestBase GetQuest(int id)
    {
        return _quests[id];
    }
}
