using System;
using System.Collections.Generic;
using LittleBitGames.QuestsModule.Common;
using LittleBitGames.QuestsModule.Configs;
using LittleBitGames.QuestsModule.Extensions;
using LittleBitGames.QuestsModule.Factories;
using LittleBitGames.QuestsModule.Quests.Controllers;
using LittleBitGames.QuestsModule.Quests.Metadata;
using Zenject;

namespace LittleBitGames.QuestsModule.Trackers
{
    public class ActiveQuestsPool
    {
        public const int PoolSize = 3;

        private readonly IQuestFactory _questFactory;
        private readonly IQuestSelector _selector;

        private readonly PooledQuest[] _quests;

        public event Action<PooledQuest> OnQuestPooled;

        public IReadOnlyList<PooledQuest> Quests =>
            new List<PooledQuest>(_quests).AsReadOnly();

        public ActiveQuestsPool(IQuestSelector selector, IQuestFactory questFactory)
        {
            _quests = new PooledQuest[PoolSize];

            _selector = selector;
            _questFactory = questFactory;
        }

        public void Initialize()
            => AppendInitialQuests();

        private void AppendInitialQuests()
        {
            for (var i = 0; i < PoolSize; i++)
                AppendQuest(GetQuestСonfig(), i);
        }

        private QuestConfig GetQuestСonfig()
            => _selector.GetQuestConfig(Quests);

        private IQuestController CreateNewQuest(QuestConfig questConfig)
            => _questFactory.Create(questConfig);

        private void AppendQuest(QuestConfig questConfig, int index)
        {
            var controller = CreateNewQuest(questConfig);
            controller.Activate();

            var keyHolder = new KeyHolder(questConfig.Metadata.Key);

            var pooledQuest = controller.AsPooledQuest(
                questConfig.Metadata,
                keyHolder,
                index);
            
            pooledQuest.AddOnStateChangeListener(OnStateChange);

            _quests[index] = pooledQuest;

            OnQuestPooled?.Invoke(pooledQuest);
        }

        private void OnStateChange(QuestState state, PooledQuest pooledQuest)
        {
            if (state is not QuestState.Done) return;

            AppendQuest(GetQuestСonfig(), pooledQuest.IndexInPool);

            pooledQuest.Dispose();
        }
    }
}