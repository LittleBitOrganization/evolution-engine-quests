using LittleBit.Modules.CoreModule;
using LittleBitGames.QuestsModule.Trackers.Models;

namespace LittleBitGames.QuestsModule.Trackers.Memento
{
    public class AchievementTrackerModelCaretaker
    {
        private readonly StorageData<AchievementTrackerModelMemento> _storageData;
        private readonly IAchievementTrackerModel _model;
        private const string DataNamingPrefix = "Tracking";

        public AchievementTrackerModelCaretaker(
            IAchievementTrackerModel model,
            IDataStorageService dataStorageService)
        {
            _model = model;

            _storageData = dataStorageService
                .CreateDataWrapper<AchievementTrackerModelMemento>(this, model.KeyHolder.GetKey());

            Restore();
            Subscribe();
        }


        private void Subscribe()
        {
            _model.TrackableSlot.OnValueChange += OnSlotValueChange;
        }

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