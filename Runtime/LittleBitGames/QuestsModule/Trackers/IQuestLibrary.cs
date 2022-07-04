using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using LittleBitGames.QuestsModule.Configs;
using LittleBitGames.QuestsModule.Quests.Metadata;

namespace LittleBitGames.QuestsModule.Trackers
{
    public interface IQuestLibrary
    {
        IReadOnlyList<QuestConfig> Configs { get; }
        Dictionary<IQuestCategory, ReadOnlyCollection<QuestConfig>> ConfigsGroupedByCategory { get; }
        IReadOnlyList<QuestCategory> Categories { get; }
        IReadOnlyList<QuestConfig> Search(Func<QuestConfig, bool> condition);
        T[] Search<T>(Func<T, bool> condition) where T : QuestConfig;
    }
}