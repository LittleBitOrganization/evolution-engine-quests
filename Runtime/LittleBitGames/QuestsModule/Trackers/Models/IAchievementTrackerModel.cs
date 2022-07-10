using System;
using LittleBit.Modules.CoreModule;
using LittleBit.Modules.Description;
using LittleBitGames.QuestsModule.Quests.Controllers;
using LittleBitGames.QuestsModule.Trackers.Memento;
using LittleBitGames.QuestsModule.Trackers.Metadata;

namespace LittleBitGames.QuestsModule.Trackers.Models
{
    public interface IAchievementTrackerModel : IOriginator<AchievementTrackerModelMemento>
    {
        public event Action<ReadOnlyQuestProgress> OnProgressChange;
        public ITrackable TrackableSlot { get; }
        public IKeyHolder KeyHolder { get; }
        public TrackRelativity TrackRelativity { get; }
        public ReadOnlyQuestProgress Progress { get; }

        public void UpdateCurrentValue(double newValue);
    }
}