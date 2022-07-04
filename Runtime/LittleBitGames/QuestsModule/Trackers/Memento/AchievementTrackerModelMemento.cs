using System;
using LittleBit.Modules.CoreModule;
using UnityEngine;

namespace LittleBitGames.QuestsModule.Trackers.Memento
{
    [Serializable]
    public class AchievementTrackerModelMemento : Data
    {
        [field: SerializeField] public double CurrentValue { get; }

        public AchievementTrackerModelMemento(double currentValue)
            => CurrentValue = currentValue;

        public AchievementTrackerModelMemento() { }
    }
}