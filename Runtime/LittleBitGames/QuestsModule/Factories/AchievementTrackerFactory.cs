using System.IO;
using LittleBit.Modules.CoreModule;
using LittleBitGames.QuestsModule.Collections;
using LittleBitGames.QuestsModule.Trackers.Collections;
using LittleBitGames.QuestsModule.Trackers.Controllers;
using LittleBitGames.QuestsModule.Trackers.Memento;
using LittleBitGames.QuestsModule.Trackers.Metadata;
using LittleBitGames.QuestsModule.Trackers.Models;

namespace LittleBitGames.QuestsModule.Factories
{
    public class AchievementTrackerFactory : IAchievementTrackerFactory
    {
        private readonly IWarehousesContainer _warehousesContainer;
        private readonly AchievementSlots _achievementSlots;
        private readonly AchievementModelKeyHolderFactory _keyHolderFactory;
        private readonly ICreator _creator;

        public AchievementTrackerFactory(
            ICreator creator,
            IWarehousesContainer warehousesContainer,
            AchievementSlots achievementSlots)
        {
            _creator = creator;
            _achievementSlots = achievementSlots;
            _warehousesContainer = warehousesContainer;
            _keyHolderFactory = new();
        }

        public ITrackerController Create(ISlotTrackingData config) => config switch
        {
            IAchievementSlotTrackingData achievementSlotTrackingData =>
                CreateAchievementSlotTracker(achievementSlotTrackingData,
                    GetAchievementSlotAsTrackable(achievementSlotTrackingData)),

            IWarehouseSlotTrackingData warehouseSlotTrackingData =>
                CreateWarehouseSlotTracker(warehouseSlotTrackingData,
                    GetWarehouseSlotAsTrackable(warehouseSlotTrackingData))
        };

        private ITrackerController CreateWarehouseSlotTracker(
            IWarehouseSlotTrackingData trackingData,
            ITrackable trackable)
        {
            var warehouseSlotKey = trackingData.WarehouseKeyHolder.GetKey();
            var resourceKey = trackingData.ResourceConfig.GetKey();

            var trackableSlotKey = Path.Combine(warehouseSlotKey, resourceKey);

            return CreateTracker(trackingData, trackable, trackableSlotKey);
        }

        private ITrackerController CreateAchievementSlotTracker(
            IAchievementSlotTrackingData trackingData,
            ITrackable trackable)
        {
            var trackableSlotKey = trackingData.AchievementSlotKeyHolder.GetKey();

            return CreateTracker(trackingData, trackable, trackableSlotKey);
        }

        private ITrackerController CreateTracker<T>(T trackingData, ITrackable trackable, string trackableKey)
            where T : ISlotTrackingData
        {
            var keyHolder = _keyHolderFactory.Create(trackingData, trackableKey);

            var model = _creator.Instantiate<AchievementTrackerModel>(trackable, trackingData, keyHolder);
            var caretaker = _creator.Instantiate<AchievementTrackerModelCaretaker>(model);
            var controller = _creator.Instantiate<AchievementTrackerController>(model);

            return controller;
        }

        private ITrackable GetWarehouseSlotAsTrackable(IWarehouseSlotTrackingData data)
            => _warehousesContainer.TryGetItem(data.WarehouseKeyHolder.GetKey()).GetSlotTrackable(data.ResourceConfig);

        private ITrackable GetAchievementSlotAsTrackable(IAchievementSlotTrackingData data)
            => _achievementSlots.TryGetItem(data.AchievementSlotKeyHolder.GetKey());
    }
}