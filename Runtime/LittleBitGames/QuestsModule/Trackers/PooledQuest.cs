using System;
using LittleBit.Modules.Description;
using LittleBitGames.QuestsModule.Configs;
using LittleBitGames.QuestsModule.Quests.Controllers;
using LittleBitGames.QuestsModule.Quests.Metadata;

namespace LittleBitGames.QuestsModule.Trackers
{
    public class PooledQuest : IDisposable
    {
        public IQuestController Controller { get; }
        public QuestConfig Config { get; }
        public IKeyHolder KeyHolder { get; }

        public int IndexInPool { get; }

        private Action<QuestState, PooledQuest> _onStateChangeDelegate;


        public PooledQuest(IQuestController controller, QuestConfig config, IKeyHolder keyHolder, int indexInPool)
        {
            Controller = controller;
            Config = config;
            IndexInPool = indexInPool;
            KeyHolder = keyHolder;

            Controller.OnStateChange += OnStateChange;
        }

        public void AddOnStateChangeListener(Action<QuestState, PooledQuest> callback) =>
            _onStateChangeDelegate += callback;

        private void OnStateChange(QuestState state)
            => _onStateChangeDelegate?.Invoke(state, this);

        public void Dispose()
            => Controller.OnStateChange -= OnStateChange;
    }
}