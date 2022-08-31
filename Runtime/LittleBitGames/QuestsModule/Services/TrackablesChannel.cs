using System;
using LittleBitGames.QuestsModule.Trackers.Collections;

namespace LittleBitGames.QuestsModule.Services
{
    public class TrackablesChannel : IAchievementsChannel
    {
        private readonly TrackablesStorage _slots;

        public TrackablesChannel(TrackablesStorage slots)
            => _slots = slots;
        public void SubscribeToAchievement(string key, Action<double> onValueChangeListener)
            => _slots.TryGetItem(key).OnValueChange += onValueChangeListener;
    
        public void UnsubscribeFromAchievement(string key, Action<double> onValueChangeListener)
            => _slots.TryGetItem(key).OnValueChange -= onValueChangeListener;
    }
}