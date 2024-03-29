using System;
using LittleBitGames.QuestsModule.Quests.Memento;
using LittleBitGames.QuestsModule.Quests.Metadata;
using LittleBitGames.QuestsModule.Quests.Models;

namespace LittleBitGames.QuestsModule.Quests.Controllers
{
    public class QuestController : IQuestController
    {
        public event Action<QuestState> OnStateChange;
        public event Action<ReadOnlyQuestProgress> OnProgressChange;

        public ReadOnlyQuestProgress Progress => _model.GoalTracker.Progress;
        public QuestState State => _model.State;

        private readonly IQuestModel _model;
        private readonly QuestModelCaretaker _questModelCaretaker;

        public QuestController(IQuestModel model, ICreator creator)
        {
            _model = model;

            _questModelCaretaker = creator.Instantiate<QuestModelCaretaker>(model);
            _questModelCaretaker.RestoreModel();

            Subscribe();
        }

        public void Activate()
        {
            if (_model.State is not QuestState.Pending) return;

            _model.NextState(QuestState.Active);
        }

        public void TakeReward()
        {
            if (_model.State is not QuestState.Completed) return;

            _model.Reward.Take();
            _model.NextState(QuestState.Done);
        }

        private void Subscribe()
        {
            if (_model.GoalTracker.Progress.HasGoalBeenReached()) CompleteQuest();

            _model.GoalTracker.OnProgressChange += OnModelProgressChange;
            _model.GoalTracker.OnGoal += CompleteQuest;
            _model.OnStateChange += OnModelStateChange;
        }

        private void Unsubscribe()
        {
            _model.GoalTracker.OnProgressChange -= OnModelProgressChange;
            _model.GoalTracker.OnGoal -= CompleteQuest;
            _model.OnStateChange -= OnModelStateChange;
        }

        private void OnModelStateChange(QuestState state)
        {
            OnStateChange?.Invoke(state);

            _questModelCaretaker.BackupModel();

            if (state.Equals(QuestState.Done)) Unsubscribe();
        }

        private void OnModelProgressChange(ReadOnlyQuestProgress progress)
            => OnProgressChange?.Invoke(progress);


        private void CompleteQuest()
        {
            if (_model.State is not (QuestState.Active or QuestState.Pending)) return;

            _model.NextState(QuestState.Completed);
        }
    }
}