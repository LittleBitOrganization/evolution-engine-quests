using System;
using LittleBitGames.QuestsModule.Quests;
using LittleBitGames.QuestsModule.Services;
using LittleBitGames.QuestsModule.Trackers.Models;

namespace LittleBitGames.QuestsModule.Trackers.Controllers
{
    public class EventTrackerController : ITrackerController
    {
        private readonly IQuestChannel _questChannel;
        private readonly IEventTrackerModel _model;

        public event Action OnGoal;

        public EventTrackerController(IEventTrackerModel model, IQuestChannel questChannel)
        {
            _model = model;
            _questChannel = questChannel;
        }

        public void StartTracking() => Subscribe();

        private void Subscribe() => _questChannel.OnEventFired += OnEventFired;

        private void Unsubscribe() => _questChannel.OnEventFired -= OnEventFired;

        private void OnEventFired(QuestEventData data)
        {
            if (data.Equals(_model.QuestEventData)) HandleGoal();
        }

        private void HandleGoal()
        {
            OnGoal?.Invoke();
            Unsubscribe();
        }
    }
}