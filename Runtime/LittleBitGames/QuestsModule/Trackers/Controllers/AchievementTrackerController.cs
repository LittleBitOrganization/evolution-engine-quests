using System;
using LittleBitGames.QuestsModule.Trackers.Memento;
using LittleBitGames.QuestsModule.Trackers.Models;

namespace LittleBitGames.QuestsModule.Trackers.Controllers
{
    public class AchievementTrackerController : ITrackerController
    {
        public event Action OnGoal;

        private readonly AchievementTrackerModel _model;
        private readonly AchievementTrackerModelCaretaker _caretaker;

        public AchievementTrackerController(AchievementTrackerModel model)
            => _model = model;

        public void StartTracking() => Subscribe();

        private void Subscribe()
        {
            OnGoal += Unsubscribe;
            _model.TrackableSlot.OnValueChange += OnValueChange;
        }

        private void Unsubscribe()
        {
            OnGoal -= Unsubscribe;
            _model.TrackableSlot.OnValueChange -= OnValueChange;
        }

        private void OnValueChange(double newValue)
        {
            var delta = newValue - _model.CurrentValue;

            if (delta > 0 && _model.TargetValue > 0 || delta < 0 && _model.TargetValue < 0)
                _model.CurrentValue += Math.Abs(delta);

            if (_model.CurrentValue >= _model.TargetValue) OnGoal?.Invoke();
        }
    }
}