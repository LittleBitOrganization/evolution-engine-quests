using LittleBitGames.QuestsModule.Quests;

namespace LittleBitGames.QuestsModule.Trackers.Metadata
{
    public interface IEventTrackingData : ITrackingData
    {
        public QuestEventData QuestEventData { get; }
    }
}