using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using LittleBitGames.QuestsModule.Configs;
using LittleBitGames.QuestsModule.Quests.Metadata;

namespace LittleBitGames.QuestsModule.Trackers
{
    public class QuestLibrary : IQuestLibrary
    {
        
        public IReadOnlyList<QuestConfig> Configs { get; }

        public IReadOnlyList<QuestCategory> Categories { get; }
        
        public QuestLibrary(QuestLibraryConfig libraryConfig)
        {
            Configs = libraryConfig.QuestConfigs;
            Categories = Configs.Select(c => c.Metadata.Category).Distinct().ToList().AsReadOnly();
        }

        public IReadOnlyList<QuestConfig> Search(Func<QuestConfig, bool> condition)
            => Configs.Where(condition).ToList();

        public T[] Search<T>(Func<T, bool> condition) where T : QuestConfig =>
            Configs.OfType<T>().Where(condition).ToArray();
        
        public Dictionary<IQuestCategory, ReadOnlyCollection<QuestConfig>> ConfigsGroupedByCategory
            => Configs.GroupBy(x => x.Metadata.Category)
                .ToDictionary(x => (IQuestCategory) x.Key, y => y.ToList().AsReadOnly());

    }
}