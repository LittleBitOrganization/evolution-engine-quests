using System;
using LittleBit.Modules.Description;
using LittleBitGames.QuestsModule.Quests.Controllers;
using LittleBitGames.QuestsModule.Quests.Metadata;

namespace LittleBitGames.QuestsModule.Trackers
{
    public class PooledQuest : IDisposable
    {
        public IQuestController Controller { get; }
        public IQuestCategory Category { get; }
        public int Index { get; }
        public IKeyHolder KeyHolder { get; }

        private Action<QuestState, PooledQuest> _onStateChangeDelegate;
        

        public PooledQuest(IQuestController controller, IQuestCategory category, IKeyHolder keyHolder, int index)
        {
            Controller = controller;
            Category = category;
            Index = index;
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