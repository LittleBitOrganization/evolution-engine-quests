using System;
using LittleBit.Modules.CoreModule;
using LittleBit.Modules.Description;
using UnityEngine;

namespace LittleBitGames.QuestsModule.Trackers.Models
{
    public class AchievementSlotModel : ITrackable
    {
        [field: SerializeField] public double Value { get; }
        public IKeyHolder KeyHolder { get; }
        public event Action<double> OnValueChange;

        public AchievementSlotModel(IKeyHolder keyHolder, double value = 0)
        {
            KeyHolder = keyHolder;
            Value = value;
        }
    }
}