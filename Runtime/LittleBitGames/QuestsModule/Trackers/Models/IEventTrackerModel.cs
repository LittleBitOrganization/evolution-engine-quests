using LittleBitGames.QuestsModule.Quests;

namespace LittleBitGames.QuestsModule.Trackers.Models
{
    public interface IEventTrackerModel
    {
        QuestEventData QuestEventData { get; }
    }
}