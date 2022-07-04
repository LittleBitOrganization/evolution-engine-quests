using System.Collections.Generic;
using LittleBitGames.QuestsModule.Configs;

namespace LittleBitGames.QuestsModule.Trackers
{
    public interface IQuestSelector
    {
        QuestConfig GetQuestConfig(IReadOnlyList<PooledQuest> pooledQuests);
    }
}