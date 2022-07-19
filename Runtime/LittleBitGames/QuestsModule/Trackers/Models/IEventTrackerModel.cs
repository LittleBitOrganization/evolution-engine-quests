using System;
using LittleBit.Modules.CoreModule;
using LittleBitGames.QuestsModule.Quests;
using LittleBitGames.QuestsModule.Trackers.Memento;

namespace LittleBitGames.QuestsModule.Trackers.Models
{
    public interface IEventTrackerModel : IOriginator<EventTrackerModelMemento>
    {
        event Action OnEventFired;
        QuestEventData QuestEventData { get; }
        bool IsEventFired { get; }
        void SetEventFired();
    }
}