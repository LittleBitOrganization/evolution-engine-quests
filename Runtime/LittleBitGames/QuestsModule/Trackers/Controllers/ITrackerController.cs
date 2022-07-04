using System;

namespace LittleBitGames.QuestsModule.Trackers.Controllers
{
    public interface ITrackerController
    {
        event Action OnGoal;
        void StartTracking();
    }
}