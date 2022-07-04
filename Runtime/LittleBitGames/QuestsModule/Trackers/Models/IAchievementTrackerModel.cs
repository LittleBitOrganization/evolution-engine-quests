using LittleBit.Modules.CoreModule;
using LittleBit.Modules.Description;
using LittleBitGames.QuestsModule.Trackers.Memento;
using LittleBitGames.QuestsModule.Trackers.Metadata;

namespace LittleBitGames.QuestsModule.Trackers.Models
{
    public interface IAchievementTrackerModel : IOriginator<AchievementTrackerModelMemento>
    {
        public ITrackable TrackableSlot { get; }
        IKeyHolder KeyHolder { get; }
        public double TargetValue { get; }
        public double CurrentValue { get; set; }
        public TrackRelativity TrackRelativity { get; }
    }
}