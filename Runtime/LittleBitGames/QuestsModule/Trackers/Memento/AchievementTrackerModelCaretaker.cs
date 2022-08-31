using LittleBit.Modules.CoreModule;
using LittleBitGames.QuestsModule.Trackers.Models;

namespace LittleBitGames.QuestsModule.Trackers.Memento
{
    public class AchievementTrackerModelCaretaker
    {
        private readonly StorageData<AchievementTrackerModelMemento> _storageData;
        private readonly ITrackerModel _model;

        public AchievementTrackerModelCaretaker(
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
            _model.Trackable.OnValueChange += OnSlotValueChange;

        private void OnSlotValueChange(double value)
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