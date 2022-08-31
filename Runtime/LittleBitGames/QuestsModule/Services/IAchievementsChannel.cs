using System;

public interface IAchievementsChannel
{
    void SubscribeToAchievement(string key, Action<double> onValueChangeListener);
    void UnsubscribeFromAchievement(string key, Action<double> onValueChangeListener);
}