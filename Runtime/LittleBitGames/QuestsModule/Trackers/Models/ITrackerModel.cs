using System;
using LittleBit.Modules.CoreModule;
using LittleBit.Modules.Description;
using LittleBitGames.QuestsModule.Quests.Controllers;
using LittleBitGames.QuestsModule.Trackers.Memento;
using LittleBitGames.QuestsModule.Trackers.Metadata;

namespace LittleBitGames.QuestsModule.Trackers.Models
{
    public interface ITrackerModel : IOriginator<AchievementTrackerModelMemento>
    {
        public event Action<ReadOnlyQuestProgress> OnProgressChange;
        public string Key { get; }
        public TrackRelativity TrackRelativity { get; }
        
        public ITrackable Trackable { get; }
        public ReadOnlyQuestProgress Progress { get; }

        public void UpdateCurrentValue(double newValue);
    }
}