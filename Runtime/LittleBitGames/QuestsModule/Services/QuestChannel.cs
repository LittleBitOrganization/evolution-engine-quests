using System;
using System.IO;
using LittleBit.Modules.Description;
using LittleBitGames.QuestsModule.Quests;
using LittleBitGames.QuestsModule.Quests.Metadata;
using LittleBitGames.QuestsModule.Trackers;

namespace LittleBitGames.QuestsModule.Services
{
    public class QuestChannel : IQuestChannel
    {
        public event Action<QuestEventData> OnEventFired;

        public event Action<IKeyHolder, QuestState> OnQuestStateChange;

        public void FireEvent(QuestEventData data) => OnEventFired?.Invoke(data);

        public QuestChannel(ActiveQuestsPool questsPool)
            => questsPool.OnQuestPooled += OnQuestPooled;

        private void OnQuestPooled(PooledQuest pooledQuest)
            => pooledQuest.AddOnStateChangeListener(OnStateChange);

        private void OnStateChange(QuestState state, PooledQuest quest)
        {
            OnQuestStateChange?.Invoke(quest.KeyHolder, state);

            var eventName = Path.Combine(
                quest.KeyHolder.GetKey(),
                state.ToString());

            FireEvent(new QuestEventData(eventName));
        }
    }
}