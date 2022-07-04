using LittleBitGames.QuestsModule.Trackers.Controllers;
using LittleBitGames.QuestsModule.Trackers.Metadata;

namespace LittleBitGames.QuestsModule.Factories
{
    public interface ITrackerProvider
    {
        ITrackerController Create<T>(T data) where T : ITrackingData;
    }
}