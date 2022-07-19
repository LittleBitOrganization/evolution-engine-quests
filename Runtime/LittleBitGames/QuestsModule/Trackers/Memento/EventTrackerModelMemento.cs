using System;
using LittleBit.Modules.CoreModule;
using UnityEngine;

namespace LittleBitGames.QuestsModule.Trackers.Memento
{
    [Serializable]
    public class EventTrackerModelMemento : Data
    {
        [field: SerializeField] public bool EventFired { get; private set; }

        public EventTrackerModelMemento(bool eventFired)
            => EventFired = eventFired;

        public EventTrackerModelMemento() { }
    }
}