using System;
using LittleBitGames.QuestsModule.Quests.Controllers;
using LittleBitGames.QuestsModule.Trackers.Memento;
using LittleBitGames.QuestsModule.Trackers.Models;
using LittleBitGames.QuestsModule.Trackers.ProgressCalculators;

namespace LittleBitGames.QuestsModule.Trackers.Controllers
{
    public class TrackerController : ITrackerController
    {
        public event Action OnGoal;
        public event Action<ReadOnlyQuestProgress> OnProgressChange;
        
        private readonly TrackerModel _model;
        private readonly IProgressSetter _progressSetter;
        private readonly TrackerModelCaretaker _caretaker;
        
        public ReadOnlyQuestProgress Progress => _model.Progress;
        public TrackerController(TrackerModel model, IProgressSetter progressSetter) =>
            (_model, _progressSetter) = (model, progressSetter);

        public void StartTracking()
        {
            Subscribe();
            OnTrackableValueChange(_model.Trackable.Value);
        }

        private void Subscribe()
        {
            OnGoal += Unsubscribe;

            _model.Trackable.OnValueChange += OnTrackableValueChange;
            _model.OnProgressChange += OnModelProgressChange;
        }

        private void Unsubscribe()
        {
            OnGoal -= Unsubscribe;

            _model.Trackable.OnValueChange -= OnTrackableValueChange;
            _model.OnProgressChange -= OnModelProgressChange;
        }

        private void OnTrackableValueChange(double newValue) =>
            _progressSetter.UpdateProgress(_model, newValue);

        private void OnModelProgressChange(ReadOnlyQuestProgress progress)
        {
            OnProgressChange?.Invoke(progress);
            
            if(progress.HasGoalBeenReached()) OnGoal?.Invoke();
        }
    }
}