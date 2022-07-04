using LittleBitGames.QuestsModule.Trackers.Controllers;
using LittleBitGames.QuestsModule.Trackers.Metadata;
using LittleBitGames.QuestsModule.Trackers.Models;

namespace LittleBitGames.QuestsModule.Factories
{
    public class EventTrackerFactory : IEventTrackerFactory
    {
        private readonly ICreator _creator;

        public EventTrackerFactory(ICreator creator) 
            => _creator = creator;
        
        
        public ITrackerController Create(IEventTrackingData data)
        {
            var model = _creator.Instantiate<EventTrackerModel>(data);
            var controller = _creator.Instantiate<EventTrackerController>(model);
            
            return controller;
        }
    }
}