using System;
using LittleBit.Modules.CoreModule;
using UnityEngine;

namespace LittleBitGames.QuestsModule.Trackers.Models
{
    public class AchievementSlotModel : ITrackable
    {
        [field: SerializeField] public double Value { get; private set; }
        public event Action<double> OnValueChange;
        
        public AchievementSlotModel(double value = 0) =>
            Value = value;

        public void SetNewValue(double value)
        {
            Value = value;
            OnValueChange?.Invoke(Value);
        }

        public void IncreaseValue(double value)
        {
            Value += value;
            OnValueChange?.Invoke(Value);
        }
    }
}