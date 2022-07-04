using System;
using LittleBitGames.QuestsModule.Quests.Metadata;

namespace LittleBitGames.QuestsModule.Quests.Controllers
{
    public interface IQuestController
    {
        event Action<QuestState> OnStateChange;
        
        void Activate();
        void TakeReward();
    }
}