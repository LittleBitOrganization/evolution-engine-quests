using System;
using LittleBitGames.QuestsModule.Quests.Controllers;

namespace LittleBitGames.QuestsModule.Trackers.Controllers
{
    public interface ITrackerController
    {
        public event Action<ReadOnlyQuestProgress> OnProgressChange;
        ReadOnlyQuestProgress Progress { get; }
        event Action OnGoal;
        void StartTracking();
    }
}