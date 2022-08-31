using System;
using LittleBitGames.QuestsModule.Trackers.Models;

namespace LittleBitGames.QuestsModule.Trackers.ProgressCalculators
{
    public class DeltaProgressSetter : IProgressSetter
    {
        public void UpdateProgress(TrackerModel trackerModel, double value)
        {
            var progress = trackerModel.Progress;

            var delta = value - progress.CurrentValue;

            if (delta > 0 && progress.TargetValue > 0 || delta < 0 && progress.TargetValue < 0)
                trackerModel.UpdateCurrentValue(progress.CurrentValue + Math.Abs(delta));
        }
    }
}