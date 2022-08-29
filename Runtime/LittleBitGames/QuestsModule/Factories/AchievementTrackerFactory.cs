using System;
using System.IO;
using System.Linq;
using LittleBit.Modules.CoreModule;
using LittleBit.Modules.Description;
using LittleBit.Modules.Warehouse.Configs;
using LittleBitGames.QuestsModule.Collections;
using LittleBitGames.QuestsModule.Trackers;
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

            IWarehouseSlotsTrackingData warehouseSlotTrackingData =>
                CreateWarehouseSlotTracker(warehouseSlotTrackingData)
        };

        private ITrackerController CreateWarehouseSlotTracker(IWarehouseSlotsTrackingData trackingData)
        {
            var filteredConfigs = trackingData.WarehouseConfigs
                .Where(x => x)
                .Select(x => x.Config);

            var trackablesComposition = new TrackablesComposition();
            
            foreach (var config in filteredConfigs)
                GetWarehouseSlotAsTrackableWhenAdded(config, trackingData.ResourceConfig,
                    trackable => trackablesComposition.AddTrackable(trackable));
            
            var warehouseSlotKey = trackingData.WarehouseConfigs
                .Select(x => x.Config.GetKey())
                .Aggregate(Path.Combine);

            var resourceKey = trackingData.ResourceConfig.GetKey();

            var trackableSlotKey = Path.Combine(warehouseSlotKey, resourceKey);

            return CreateTracker(trackingData, trackablesComposition, trackableSlotKey);
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

        private ITrackable GetWarehouseSlotAsTrackable(WarehouseConfig warehouseConfig, IResourceConfig resourceConfig)
            => _warehousesContainer.TryGetItem(warehouseConfig).GetSlotTrackable(resourceConfig);

        private void GetWarehouseSlotAsTrackableWhenAdded(WarehouseConfig warehouseConfig,
            IResourceConfig resourceConfig, Action<ITrackable> onAdded) =>
            _warehousesContainer.GetItemWhenAdded(warehouseConfig,
                _ => onAdded?.Invoke(GetWarehouseSlotAsTrackable(warehouseConfig, resourceConfig)));

        private ITrackable GetAchievementSlotAsTrackable(IAchievementSlotTrackingData data)
            => _achievementSlots.TryGetItem(data.AchievementSlotKeyHolder.GetKey());
    }
}