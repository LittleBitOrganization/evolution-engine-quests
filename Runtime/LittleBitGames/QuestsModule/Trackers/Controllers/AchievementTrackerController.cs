using System;
using LittleBitGames.QuestsModule.Quests.Controllers;
using LittleBitGames.QuestsModule.Trackers.Memento;
using LittleBitGames.QuestsModule.Trackers.Models;

namespace LittleBitGames.QuestsModule.Trackers.Controllers
{
    public class AchievementTrackerController : ITrackerController
    {
        public event Action OnGoal;
        public event Action<ReadOnlyQuestProgress> OnProgressChange;
        
        private readonly AchievementTrackerModel _model;
        private readonly AchievementTrackerModelCaretaker _caretaker;
        
        public ReadOnlyQuestProgress Progress => _model.Progress;
        
        public AchievementTrackerController(AchievementTrackerModel model)
            => _model = model;
        

        public void StartTracking()
        {
            Subscribe();
            OnTrackableValueChange(_model.TrackableSlot.Value);
        }

        private void Subscribe()
        {
            OnGoal += Unsubscribe;

            _model.TrackableSlot.OnValueChange += OnTrackableValueChange;
            _model.OnProgressChange += OnModelProgressChange;
        }

        private void Unsubscribe()
        {
            OnGoal -= Unsubscribe;

            _model.TrackableSlot.OnValueChange -= OnTrackableValueChange;
            _model.OnProgressChange -= OnModelProgressChange;
        }

        private void OnTrackableValueChange(double newValue)
        {
            var progress = _model.Progress;

            var delta = newValue - progress.CurrentValue;

            if (delta > 0 && progress.TargetValue > 0 || delta < 0 && progress.TargetValue < 0)
                _model.UpdateCurrentValue(progress.CurrentValue + Math.Abs(delta));
        }

        private void OnModelProgressChange(ReadOnlyQuestProgress progress)
        {
            if (progress.CurrentValue >= progress.TargetValue) OnGoal?.Invoke();
        }
    }
}