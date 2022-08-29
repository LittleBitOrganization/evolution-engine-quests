using System;
using LittleBitGames.QuestsModule.Trackers.Models;

namespace LittleBitGames.QuestsModule.Trackers.ProgressCalculators
{
    public class IncrementalProgressSetter : IProgressSetter
    {
        public void UpdateProgress(AchievementTrackerModel trackerModel, double value)
        {
            var progress = trackerModel.Progress;
            
            var newValue = progress.TargetValue > 0 ? Math.Max(0, value) : Math.Min(0, value);
            
            trackerModel.UpdateCurrentValue(progress.CurrentValue + newValue);
        }
    }
}