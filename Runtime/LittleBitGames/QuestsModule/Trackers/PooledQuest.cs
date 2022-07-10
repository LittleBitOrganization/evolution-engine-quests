using System;
using LittleBit.Modules.Description;
using LittleBitGames.QuestsModule.Quests.Controllers;
using LittleBitGames.QuestsModule.Quests.Metadata;

namespace LittleBitGames.QuestsModule.Trackers
{
    public class PooledQuest : IDisposable
    {
        public IQuestController Controller { get; }
        public QuestMetadata Metadata { get; }
        public IKeyHolder KeyHolder { get; }
        
        public int IndexInPool { get; }

        private Action<QuestState, PooledQuest> _onStateChangeDelegate;
        

        public PooledQuest(IQuestController controller, QuestMetadata metadata, IKeyHolder keyHolder, int indexInPool)
        {
            Controller = controller;
            Metadata = metadata;
            IndexInPool = indexInPool;
            KeyHolder = keyHolder;
        }

        public void AddOnStateChangeListener(Action<QuestState, PooledQuest> callback)
        {
            Controller.OnStateChange += OnStateChange;

            _onStateChangeDelegate = callback;
        }

        private void OnStateChange(QuestState state)
            => _onStateChangeDelegate?.Invoke(state, this);

        public void Dispose()
            => Controller.OnStateChange -= OnStateChange;
    }
}