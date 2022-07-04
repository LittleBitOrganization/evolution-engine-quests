using System;
using LittleBitGames.QuestsModule.Quests;

namespace LittleBitGames.QuestsModule.Services
{
    public interface IQuestChannel
    {
        event Action<QuestEventData> OnEventFired;
        
        void FireEvent(QuestEventData data);
    }
}