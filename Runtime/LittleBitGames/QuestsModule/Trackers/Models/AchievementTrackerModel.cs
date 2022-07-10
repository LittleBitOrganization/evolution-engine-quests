using System;
using LittleBit.Modules.CoreModule;
using LittleBit.Modules.Description;
using LittleBitGames.QuestsModule.Quests.Controllers;
using LittleBitGames.QuestsModule.Trackers.Memento;
using LittleBitGames.QuestsModule.Trackers.Metadata;

namespace LittleBitGames.QuestsModule.Trackers.Models
{
    public class AchievementTrackerModel : IAchievementTrackerModel
    {
        public event Action<ReadOnlyQuestProgress> OnProgressChange;
        public ITrackable TrackableSlot { get; }
        public IKeyHolder KeyHolder { get; }
        public TrackRelativity TrackRelativity { get; }
        public ReadOnlyQuestProgress Progress
            => _progress.AsReadOnly();

        private readonly QuestProgress _progress;

        public AchievementTrackerModel(ITrackable trackable, ISlotTrackingData trackingData, IKeyHolder keyHolder)
        {
            TrackableSlot = trackable;
            TrackRelativity = trackingData.TrackRelativity;
            KeyHolder = keyHolder;

            _progress = new(trackable.Value, trackingData.TargetValue);
        }

        public void UpdateCurrentValue(double newValue)
        {
            _progress.CurrentValue = newValue;
            
            OnProgressChange?.Invoke(Progress);
        }

        public AchievementTrackerModelMemento Backup()
            => new(_progress.CurrentValue);

        public void Restore(AchievementTrackerModelMemento data)
            => UpdateCurrentValue(data.CurrentValue);
    }
}