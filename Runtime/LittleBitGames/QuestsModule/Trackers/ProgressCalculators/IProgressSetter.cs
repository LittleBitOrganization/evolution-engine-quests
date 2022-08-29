using LittleBitGames.QuestsModule.Trackers.Models;

namespace LittleBitGames.QuestsModule.Trackers.ProgressCalculators
{
    public interface IProgressSetter
    {
        public void UpdateProgress(AchievementTrackerModel trackerModel, double value);
    }
}