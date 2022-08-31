using LittleBitGames.QuestsModule.Trackers.Controllers;
using LittleBitGames.QuestsModule.Trackers.Metadata;
using LittleBitGames.QuestsModule.Trackers.Models;

namespace LittleBitGames.QuestsModule.Factories
{
    public class AchievementTrackerFactory : TrackerFactory<IAchievementTrackingData>
    {
        public AchievementTrackerFactory(AchievementSlotKeyFactory keyFactory, ICreator creator) : base(keyFactory,
            creator) { }

        public override ITrackerController Create(IAchievementTrackingData data) =>
            CreateTracker(data, new AchievementSlotModel(), data.AchievementKeyHolder.GetKey());
    }
}