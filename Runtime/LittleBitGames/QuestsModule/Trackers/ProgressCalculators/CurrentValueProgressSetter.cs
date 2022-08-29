using LittleBitGames.QuestsModule.Trackers.Models;

namespace LittleBitGames.QuestsModule.Trackers.ProgressCalculators
{
    public class CurrentValueProgressSetter : IProgressSetter
    {
        public void UpdateProgress(AchievementTrackerModel trackerModel, double value) =>
            trackerModel.UpdateCurrentValue(value);
    }
}