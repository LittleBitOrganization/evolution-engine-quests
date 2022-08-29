using System;
using LittleBitGames.QuestsModule.Quests.Controllers;
using LittleBitGames.QuestsModule.Trackers.Memento;
using LittleBitGames.QuestsModule.Trackers.Models;
using LittleBitGames.QuestsModule.Trackers.ProgressCalculators;

namespace LittleBitGames.QuestsModule.Trackers.Controllers
{
    public class AchievementTrackerController : ITrackerController
    {
        public event Action OnGoal;
        public event Action<ReadOnlyQuestProgress> OnProgressChange;
        
        private readonly AchievementTrackerModel _model;
        private readonly IProgressSetter _progressSetter;
        private readonly AchievementTrackerModelCaretaker _caretaker;
        
        public ReadOnlyQuestProgress Progress => _model.Progress;
        public AchievementTrackerController(AchievementTrackerModel model, IProgressSetter progressSetter) =>
            (_model, _progressSetter) = (model, progressSetter);

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

        private void OnTrackableValueChange(double newValue) =>
            _progressSetter.UpdateProgress(_model, newValue);

        private void OnModelProgressChange(ReadOnlyQuestProgress progress)
        {
            OnProgressChange?.Invoke(progress);
            
            if (progress.CurrentValue >= progress.TargetValue) OnGoal?.Invoke();
        }
    }
}