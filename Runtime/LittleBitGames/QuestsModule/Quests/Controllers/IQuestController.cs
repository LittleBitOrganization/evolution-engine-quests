using System;
using LittleBitGames.QuestsModule.Quests.Metadata;

namespace LittleBitGames.QuestsModule.Quests.Controllers
{
    public interface IQuestController
    {
        public event Action<QuestState> OnStateChange;
        public event Action<ReadOnlyQuestProgress> OnProgressChange;
        public ReadOnlyQuestProgress Progress { get; }
        public QuestState State { get; }
        public void Activate();
        public void TakeReward();
    }
}