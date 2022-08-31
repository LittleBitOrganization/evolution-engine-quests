using System;
using LittleBitGames.QuestsModule.Trackers.Models;

namespace LittleBitGames.QuestsModule.Trackers.ProgressCalculators
{
    public class IncrementalProgressSetter : IProgressSetter
    {
        private double _prevValue;

        public void UpdateProgress(TrackerModel trackerModel, double value)
        {
            var progress = trackerModel.Progress;

            var delta = value - _prevValue;

            if (delta > 0 && progress.TargetValue > 0 || delta < 0 && progress.TargetValue < 0)
                trackerModel.UpdateCurrentValue(progress.CurrentValue + Math.Abs(delta));

            _prevValue = value;
        }
    }
}