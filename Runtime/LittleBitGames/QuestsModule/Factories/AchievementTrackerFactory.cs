using LittleBitGames.QuestsModule.Trackers.Collections;
using LittleBitGames.QuestsModule.Trackers.Controllers;
using LittleBitGames.QuestsModule.Trackers.Metadata;
using LittleBitGames.QuestsModule.Trackers.Models;

namespace LittleBitGames.QuestsModule.Factories
{
    public class AchievementTrackerFactory : TrackerFactory<IAchievementTrackingData>
    {
        private readonly AchievementsContainer _achievementsContainer;
        public AchievementTrackerFactory(ICreator creator, AchievementsContainer achievementsContainer) : base(creator) =>
            _achievementsContainer = achievementsContainer;

        public override ITrackerController Create(IAchievementTrackingData data)
        {
            var trackable = new AchievementSlotModel();
            
            _achievementsContainer.AddAchievement(data.TrackerKey, trackable);
            
            return CreateTracker(data, trackable);
        }
    }
}