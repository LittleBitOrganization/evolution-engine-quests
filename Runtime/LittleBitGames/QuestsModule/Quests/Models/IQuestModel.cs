using System;
using LittleBit.Modules.CoreModule;
using LittleBit.Modules.Description;
using LittleBitGames.QuestsModule.Quests.Memento;
using LittleBitGames.QuestsModule.Quests.Metadata;
using LittleBitGames.QuestsModule.Rewards;
using LittleBitGames.QuestsModule.Trackers.Controllers;

namespace LittleBitGames.QuestsModule.Quests.Models
{
    public interface IQuestModel : IOriginator<QuestModelMemento>
    {
        public event Action<QuestState> OnStateChange;
        QuestState State { get; }
        ITrackerController GoalTracker { get; }
        IRewardModel Reward { get; }
        IKeyHolder KeyHolder { get; }
        void NextState(QuestState state);
    }
}