using System;

namespace LittleBitGames.QuestsModule.Services
{
    public interface ITrackablesChannel
    {
        void SubscribeToAchievement(string key, Action<double> onValueChangeListener);
        void UnsubscribeFromAchievement(string key, Action<double> onValueChangeListener);
    }
}