using System;
using LittleBitGames.QuestsModule.Trackers.Collections;

public class AchievementsChannel : IAchievementsChannel
{
    private readonly AchievementSlots _slots;

    public AchievementsChannel(AchievementSlots slots)
        => _slots = slots;

    public void IncreaseAchievementValue(string key, double value)
        => _slots.IncreaseSlotValue(key, value);

    public void SetAchievementValue(string key, double value)
        => _slots.IncreaseSlotValue(key, value);

    public void SubscribeToAchievement(string key, Action<double> onValueChangeListener)
        => _slots.TryGetItem(key).OnValueChange += onValueChangeListener;
    
    public void UnsubscribeFromAchievement(string key, Action<double> onValueChangeListener)
        => _slots.TryGetItem(key).OnValueChange -= onValueChangeListener;
}