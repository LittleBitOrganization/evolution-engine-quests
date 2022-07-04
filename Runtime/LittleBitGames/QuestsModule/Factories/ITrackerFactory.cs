using LittleBitGames.QuestsModule.Trackers.Controllers;

namespace LittleBitGames.QuestsModule.Factories
{
    public interface ITrackerFactory<T>
    {
        public ITrackerController Create(T data);
    }
}