using LittleBitGames.QuestsModule.Quests;
using LittleBitGames.QuestsModule.Trackers.Metadata;

namespace LittleBitGames.QuestsModule.Trackers.Models
{
    public class EventTrackerModel : IEventTrackerModel
    {
        public QuestEventData QuestEventData { get; }

        public EventTrackerModel(IEventTrackingData data)
            => QuestEventData = data.QuestEventData;
    }
}