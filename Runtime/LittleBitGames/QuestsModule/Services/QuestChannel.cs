using System;
using LittleBitGames.QuestsModule.Quests;

namespace LittleBitGames.QuestsModule.Services
{
    public class QuestChannel : IQuestChannel
    {
        public event Action<QuestEventData> OnEventFired;

        public void FireEvent(QuestEventData data) => OnEventFired?.Invoke(data);
    }
}