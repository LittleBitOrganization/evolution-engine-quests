using System.IO;
using LittleBit.Modules.CoreModule;
using LittleBitGames.QuestsModule.Trackers.Models;

namespace LittleBitGames.QuestsModule.Trackers.Memento
{
    public class EventTrackerModelCaretaker
    {
        private readonly StorageData<EventTrackerModelMemento> _storageData;
        private readonly IEventTrackerModel _model;

        public EventTrackerModelCaretaker(
            IEventTrackerModel model,
            IDataStorageService dataStorageService)
        {
            _model = model;

            _storageData = dataStorageService
                .CreateDataWrapper<EventTrackerModelMemento>(this, GetKeyByEventName(model.QuestEventData.Name));

            Restore();
            Subscribe();
        }

        private string GetKeyByEventName(string eventName)
            => Path.Combine(eventName, "tracker");

        private void Subscribe() => _model.OnEventFired += Backup;
        
        private void Backup()
        {
            _storageData.Value = _model.Backup();
            _storageData.Save();
        }

        public void Restore()
        {
            _storageData.Update();
            _model.Restore(_storageData.Value);
        }
        
        //TODO: add unsubscribe!
    }
}