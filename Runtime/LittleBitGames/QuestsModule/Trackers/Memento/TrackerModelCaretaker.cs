using LittleBit.Modules.CoreModule;
using LittleBitGames.QuestsModule.Quests.Controllers;
using LittleBitGames.QuestsModule.Trackers.Models;

namespace LittleBitGames.QuestsModule.Trackers.Memento
{
    public class TrackerModelCaretaker
    {
        private readonly StorageData<AchievementTrackerModelMemento> _storageData;
        private readonly ITrackerModel _model;

        public TrackerModelCaretaker(
            ITrackerModel model,
            IDataStorageService dataStorageService)
        {
            _model = model;

            _storageData = dataStorageService
                .CreateDataWrapper<AchievementTrackerModelMemento>(this, model.Key);

            Restore();
            Subscribe();
        }


        private void Subscribe() =>
            _model.OnProgressChange += OnSlotValueChange;

        private void OnSlotValueChange(ReadOnlyQuestProgress progress)
            => Backup();


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
    }
}