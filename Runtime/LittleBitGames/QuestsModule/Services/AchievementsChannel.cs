using System;
using LittleBitGames.QuestsModule.Trackers.Collections;

namespace LittleBitGames.QuestsModule.Services
{
    public class AchievementsChannel : IAchievementsChannel
    {
        private readonly AchievementsContainer _slots;

        public AchievementsChannel(AchievementsContainer slots)
            => _slots = slots;
        
        public void SubscribeToAchievement(string key, Action<double> onValueChangeListener)
            => _slots.GetAchievement(key).OnValueChange += onValueChangeListener;
    
        public void UnsubscribeFromAchievement(string key, Action<double> onValueChangeListener)
            => _slots.GetAchievement(key).OnValueChange -= onValueChangeListener;
    }
}