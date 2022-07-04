using System.Collections.Generic;
using System.Linq;
using LittleBit.Modules.CoreModule;
using LittleBitGames.QuestsModule.Configs;
using LittleBitGames.QuestsModule.Quests.Memento;
using LittleBitGames.QuestsModule.Quests.Metadata;
using UnityEngine;

namespace LittleBitGames.QuestsModule.Trackers
{
    public class QuestSelector : IQuestSelector
    {
        private readonly IQuestLibrary _library;
        private readonly IDataStorageService _dataStorageService;

        public QuestSelector(IQuestLibrary library, IDataStorageService dataStorageService)
        {
            _dataStorageService = dataStorageService;
            _library = library;
        }

        public QuestConfig GetQuestConfig(IReadOnlyList<PooledQuest> pooledQuests)
        {
            var currentCategories = pooledQuests.Select(p => p.Category).ToList();
            var targetCategories = _library.Categories.Except(currentCategories).ToList();
            var targetCategory = targetCategories[Random.Range(0, targetCategories.Count)];

            return _library.ConfigsGroupedByCategory[targetCategory]
                .First(config => GetMemento(config.Metadata.Key).State is QuestState.Pending);
        }

        private QuestModelMemento GetMemento(string key)
            => _dataStorageService.GetData<QuestModelMemento>(key);
    }
}