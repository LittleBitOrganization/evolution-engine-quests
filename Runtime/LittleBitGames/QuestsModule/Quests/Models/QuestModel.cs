using System;
using LittleBit.Modules.Description;
using LittleBitGames.QuestsModule.Quests.Memento;
using LittleBitGames.QuestsModule.Quests.Metadata;
using LittleBitGames.QuestsModule.Rewards;
using LittleBitGames.QuestsModule.Trackers.Controllers;

namespace LittleBitGames.QuestsModule.Quests.Models
{
    public class QuestModel : IQuestModel
    {
        public event Action<QuestState> OnStateChange;
        public IKeyHolder KeyHolder { get; }
        public QuestState State { get; private set; }
        public ITrackerController GoalTracker { get; }
        public IRewardModel Reward { get; }

        public QuestModel(IKeyHolder keyHolder, IRewardModel reward, ITrackerController goalTracker)
        {
            Reward = reward;
            GoalTracker = goalTracker;
            KeyHolder = keyHolder;
        }

        public void NextState(QuestState state)
        {
            State = state;
            OnStateChange?.Invoke(state);
        }

        public QuestModelMemento Backup()
            => new(State);

        public void Restore(QuestModelMemento memento) 
            => State = memento.State;
    }
}