using System;
using LittleBitGames.QuestsModule.Trackers.Collections;

namespace LittleBitGames.QuestsModule.Services
{
    public class AchievementsChannel : IAchievementsChannel
    {
        private readonly AchievementsContainer _slots;

        public AchievementsChannel(AchievementsContainer slots)
            => _slots = slots;

        public void Subscribe(string achievementSlotKey, Action<double> onValueChangeListener)
            => _slots.GetAchievement(achievementSlotKey).OnValueChange += onValueChangeListener;

        public void Unsubscribe(string achievementSlotKey, Action<double> onValueChangeListener)
            => _slots.GetAchievement(achievementSlotKey).OnValueChange -= onValueChangeListener;

        public void SetValue(string achievementSlotKey, double value)
            => _slots.GetAchievement(achievementSlotKey).SetNewValue(value);

        public void AddOne(string achievementSlotKey)
            => _slots.GetAchievement(achievementSlotKey).AddValue(1);

        public void AddValue(string achievementSlotKey, double value)
            => _slots.GetAchievement(achievementSlotKey).AddValue(value);

        public void SubtractOne(string achievementSlotKey)
            => _slots.GetAchievement(achievementSlotKey).AddValue(-1);

        public void SubtractValue(string achievementSlotKey, double value)
            => _slots.GetAchievement(achievementSlotKey).AddValue(-value);

        public double GetValue(string achievementSlotKey) =>
            _slots.GetAchievement(achievementSlotKey).Value;
    }
}