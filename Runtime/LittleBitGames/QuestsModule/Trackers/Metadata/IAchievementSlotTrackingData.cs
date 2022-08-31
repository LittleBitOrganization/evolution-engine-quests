using LittleBit.Modules.Description;

namespace LittleBitGames.QuestsModule.Trackers.Metadata
{
    public interface IAchievementSlotTrackingData : ISlotTrackingData
    {
        public IKeyHolder AchievementKeyHolder { get; }
    }
}