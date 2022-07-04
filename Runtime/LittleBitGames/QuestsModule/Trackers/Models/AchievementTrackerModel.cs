using LittleBit.Modules.CoreModule;
using LittleBit.Modules.Description;
using LittleBitGames.QuestsModule.Trackers.Memento;
using LittleBitGames.QuestsModule.Trackers.Metadata;

namespace LittleBitGames.QuestsModule.Trackers.Models
{
    public class AchievementTrackerModel : IAchievementTrackerModel
    {
        public ITrackable TrackableSlot { get; }
        public IKeyHolder KeyHolder { get; }
        public double TargetValue { get; }
        public double CurrentValue { get; set; }
        public TrackRelativity TrackRelativity { get; }

        public AchievementTrackerModel(ITrackable trackable, ISlotTrackingData trackingData, IKeyHolder keyHolder)
        {
            TrackableSlot = trackable;
            TargetValue = trackingData.TargetValue;
            TrackRelativity = trackingData.TrackRelativity;
            KeyHolder = keyHolder;
        }

        public AchievementTrackerModelMemento Backup()
            => new(CurrentValue);

        public void Restore(AchievementTrackerModelMemento data)
            => CurrentValue = data.CurrentValue;
    }
}