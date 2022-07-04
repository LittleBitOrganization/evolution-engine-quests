using LittleBit.Modules.CoreModule;
using LittleBitGames.QuestsModule.Quests.Models;

namespace LittleBitGames.QuestsModule.Quests.Memento
{
    public class QuestModelCaretaker
    {
        private readonly QuestModel _model;
        private readonly StorageData<QuestModelMemento> _storageData;

        public QuestModelCaretaker(QuestModel model, IDataStorageService dataStorageService)
        {
            _model = model;
            _storageData = dataStorageService.CreateDataWrapper<QuestModelMemento>(this, _model.KeyHolder.GetKey());
        }

        public void RestoreModel()
        {
            _storageData.Update();
            _model.Restore(_storageData.Value);
        }

        public void BackupModel()
        {
            _storageData.Value = _model.Backup();
            _storageData.Save();
        }
    }
}