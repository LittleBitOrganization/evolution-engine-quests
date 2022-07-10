using System;
using LittleBitGames.QuestsModule.Quests;
using LittleBitGames.QuestsModule.Quests.Controllers;
using LittleBitGames.QuestsModule.Services;
using LittleBitGames.QuestsModule.Trackers.Models;

namespace LittleBitGames.QuestsModule.Trackers.Controllers
{
    public class EventTrackerController : ITrackerController
    {
        public event Action<ReadOnlyQuestProgress> OnProgressChange;
        public event Action OnGoal;

        public ReadOnlyQuestProgress Progress => _progress.AsReadOnly();

        private readonly IQuestChannel _questChannel;
        private readonly IEventTrackerModel _model;
        private readonly QuestProgress _progress;


        public EventTrackerController(IEventTrackerModel model, IQuestChannel questChannel)
        {
            _model = model;
            _questChannel = questChannel;

            _progress = new(0, 1);
        }

        public void StartTracking() => Subscribe();

        private void Subscribe() => _questChannel.OnEventFired += OnEventFired;

        private void Unsubscribe() => _questChannel.OnEventFired -= OnEventFired;

        private void OnEventFired(QuestEventData data)
        {
            if (!data.Equals(_model.QuestEventData)) return;
            
            HandleGoal();
            
            OnProgressChange?.Invoke(Progress);
        }

        private void HandleGoal()
        {
            _progress.CurrentValue = 1;
            
            OnGoal?.Invoke();
            
            Unsubscribe();
        }
    }
}