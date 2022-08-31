using System;
using LittleBit.Modules.CoreModule;
using LittleBit.Modules.Description;
using LittleBitGames.QuestsModule.Quests.Controllers;
using LittleBitGames.QuestsModule.Trackers.Memento;
using LittleBitGames.QuestsModule.Trackers.Metadata;

namespace LittleBitGames.QuestsModule.Trackers.Models
{
    public class TrackerModel : ITrackerModel
    {
        public event Action<ReadOnlyQuestProgress> OnProgressChange;
        public ITrackable Trackable { get; }
        public string Key { get; }
        public TrackRelativity TrackRelativity { get; }
        public ReadOnlyQuestProgress Progress
            => _progress.AsReadOnly();

        private readonly QuestProgress _progress;

        public TrackerModel(ITrackable trackable, ITrackingData trackingData)
        {
            Trackable = trackable;
            TrackRelativity = trackingData.TrackRelativity;
            Key = trackingData.TrackerKey;

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
            => _progress.CurrentValue = data.CurrentValue;
    }
}