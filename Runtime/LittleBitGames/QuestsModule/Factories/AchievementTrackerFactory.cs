using LittleBitGames.QuestsModule.Trackers.Collections;
using LittleBitGames.QuestsModule.Trackers.Controllers;
using LittleBitGames.QuestsModule.Trackers.Metadata;

namespace LittleBitGames.QuestsModule.Factories
{
    public class AchievementTrackerFactory : TrackerFactory<IAchievementTrackingData>
    {
        private readonly AchievementsContainer _achievementsContainer;

        public AchievementTrackerFactory(ICreator creator, AchievementsContainer achievementsContainer) : base(creator) =>
            _achievementsContainer = achievementsContainer;

        public override ITrackerController Create(IAchievementTrackingData data)
        {
            var slotModel = _achievementsContainer.AddAchievement(data.AchievementKeyHolder.GetKey());

            var tracker = CreateTracker(data, slotModel);

            return tracker;
        }
    }
}