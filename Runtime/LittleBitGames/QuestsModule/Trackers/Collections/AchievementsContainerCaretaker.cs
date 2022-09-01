using System.Linq;
using LittleBit.Modules.CoreModule;
using LittleBitGames.QuestsModule.Trackers.Models;

namespace LittleBitGames.QuestsModule.Trackers.Collections
{
    public class AchievementsContainerCaretaker : Data
    {
        private readonly IDataStorageService _dataStorageService;
        private readonly AchievementsContainer _achievementsContainer;
        
        private const string AchievementsContainerKey = "AchievementsContainer";

        public AchievementsContainerCaretaker(
            IDataStorageService dataStorageService,
            AchievementsContainer achievementsContainer)
        {
            _dataStorageService = dataStorageService;

            _achievementsContainer = achievementsContainer;
            
            _achievementsContainer.Restore(Restore());

            _achievementsContainer.Slots.ToList().ForEach(SubscribeOnSlot);

            _achievementsContainer.OnAchievementAdded += (_, slot) => SubscribeOnSlot(slot);
        }

        private void SubscribeOnSlot(AchievementSlot slot) =>
            slot.OnValueChange += _ => Backup();

        private void Backup() =>
            _dataStorageService.SetData(AchievementsContainerKey, _achievementsContainer.Backup());

        private AchievementsContainerMemento Restore() =>
            _dataStorageService.GetData<AchievementsContainerMemento>(AchievementsContainerKey);
    }
}