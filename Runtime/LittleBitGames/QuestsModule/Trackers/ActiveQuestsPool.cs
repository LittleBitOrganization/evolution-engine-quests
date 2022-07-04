using System.Collections.Generic;
using LittleBitGames.QuestsModule.Configs;
using LittleBitGames.QuestsModule.Extensions;
using LittleBitGames.QuestsModule.Factories;
using LittleBitGames.QuestsModule.Quests.Controllers;
using LittleBitGames.QuestsModule.Quests.Metadata;

namespace LittleBitGames.QuestsModule.Trackers
{
    public class ActiveQuestsPool
    {
        public const int PoolSize = 3;
        
        private readonly IQuestFactory _questFactory;
        private readonly IQuestSelector _selector;

        public IReadOnlyList<PooledQuest> Quests =>
            new List<PooledQuest>(_quests).AsReadOnly();

        private readonly PooledQuest[] _quests;

        public ActiveQuestsPool(IQuestSelector selector, IQuestFactory questFactory)
        {
            _quests = new PooledQuest[PoolSize];

            _selector = selector;
            _questFactory = questFactory;

            AppendInitialQuests();
        }

        private void AppendInitialQuests()
        {
            for (var i = 0; i < PoolSize; i++) AppendQuest(GetQuestСonfig(), i);
        }

        private QuestConfig GetQuestСonfig()
            => _selector.GetQuestConfig(Quests);

        private IQuestController CreateNewQuest(QuestConfig questConfig)
            => _questFactory.Create(questConfig);

        private void AppendQuest(QuestConfig questConfig, int index)
        {
            var controller = CreateNewQuest(questConfig);
            var pooledQuest = controller.AsPooledQuest(questConfig.Metadata.Category, index);

            pooledQuest.AddOnStateChangeListener(OnStateChange);

            _quests[index] = pooledQuest;
        }

        private void OnStateChange(QuestState state, PooledQuest pooledQuest)
        {
            if (state is not QuestState.Done) return;

            AppendQuest(GetQuestСonfig(), pooledQuest.Index);

            pooledQuest.Dispose();
        }
    }
}