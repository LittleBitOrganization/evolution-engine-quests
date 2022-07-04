using LittleBitGames.QuestsModule.Configs;
using LittleBitGames.QuestsModule.Factories;
using LittleBitGames.QuestsModule.Trackers.Metadata;

namespace LittleBitGames.QuestsModule.Trackers
{
    public class TrackersInitializer
    {
        private readonly ITrackerProvider _trackerProvider;
        private readonly IQuestLibrary _questLibrary;

        public TrackersInitializer(IQuestLibrary questLibrary, ITrackerProvider trackerProvider)
        {
            _questLibrary = questLibrary;
            _trackerProvider = trackerProvider;

            CreateTrackers();
        }

        private void CreateTrackers()
        {
            var matchingQuests = _questLibrary.Search<SlotTrackingQuestConfig>(QuestAskingAbsoluteTracking);

            foreach (var quest in matchingQuests) CreateTrackerForQuest(quest);
        }

        private static bool QuestAskingAbsoluteTracking(SlotTrackingQuestConfig config)
            => config.TrackRelativity.Equals(TrackRelativity.Absolute);

        private void CreateTrackerForQuest(SlotTrackingQuestConfig config)
            => _trackerProvider.Create(config);
    }
}