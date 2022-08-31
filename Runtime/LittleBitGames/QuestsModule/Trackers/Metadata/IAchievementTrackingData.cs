using LittleBit.Modules.Description;

namespace LittleBitGames.QuestsModule.Trackers.Metadata
{
    public interface IAchievementTrackingData : ITrackingData
    {
        public IKeyHolder AchievementKeyHolder { get; }
    }
}