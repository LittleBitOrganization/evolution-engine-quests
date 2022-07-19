using System;
using LittleBitGames.QuestsModule.Quests;
using LittleBitGames.QuestsModule.Trackers.Memento;
using LittleBitGames.QuestsModule.Trackers.Metadata;

namespace LittleBitGames.QuestsModule.Trackers.Models
{
    public class EventTrackerModel : IEventTrackerModel
    {
        public event Action OnEventFired;
        public QuestEventData QuestEventData { get; }
        
        public bool IsEventFired { get; private set; }

        public void SetEventFired()
        {
            IsEventFired = true;
            OnEventFired?.Invoke();
        }

        public EventTrackerModel(IEventTrackingData data)
            => QuestEventData = data.QuestEventData;

        public EventTrackerModelMemento Backup()
            => new(IsEventFired);

        public void Restore(EventTrackerModelMemento data)
            => IsEventFired = data.EventFired;
    }
}