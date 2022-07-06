using System;

public interface IAchievementsChannel
{
    void IncreaseAchievementValue(string key, double value);
    void SetAchievementValue(string key, double value);
    void SubscribeToAchievement(string key, Action<double> onValueChangeListener);
    void UnsubscribeFromAchievement(string key, Action<double> onValueChangeListener);
}