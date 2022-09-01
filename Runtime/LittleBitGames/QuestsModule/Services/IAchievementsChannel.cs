using System;

namespace LittleBitGames.QuestsModule.Services
{
    public interface IAchievementsChannel
    {
        void Subscribe(string achievementSlotKey, Action<double> onValueChangeListener);
        void Unsubscribe(string achievementSlotKey, Action<double> onValueChangeListener);
        void SetValue(string achievementSlotKey, double value);
        void AddOne(string achievementSlotKey);
        void AddValue(string achievementSlotKey, double value);
        void SubtractOne(string achievementSlotKey);
        void SubtractValue(string achievementSlotKey, double value);
    }
}