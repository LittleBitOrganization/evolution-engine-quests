using System;
using System.IO;
using System.Linq;
using LittleBit.Modules.CoreModule;
using LittleBit.Modules.Description;
using LittleBit.Modules.Warehouse.Configs;
using LittleBitGames.QuestsModule.Collections;
using LittleBitGames.QuestsModule.Trackers;
using LittleBitGames.QuestsModule.Trackers.Controllers;
using LittleBitGames.QuestsModule.Trackers.Models;

namespace LittleBitGames.QuestsModule.Factories
{
    public class WarehouseTrackerFactory : TrackerFactory<IWarehouseSlotTrackingData>
    {
        private readonly IWarehousesContainer _warehousesContainer;

        public WarehouseTrackerFactory(AchievementSlotKeyFactory keyFactory, ICreator creator,
            IWarehousesContainer warehousesContainer) : base(keyFactory, creator) =>
            _warehousesContainer = warehousesContainer;

        public override ITrackerController Create(IWarehouseSlotTrackingData data)
        {
            var filteredConfigs = data.WarehouseConfigs
                .Where(x => x)
                .Select(x => x.Config);

            var trackablesComposition = new TrackablesComposition();

            foreach (var config in filteredConfigs)
            {
                GetTrackableWhenAdded(config, data.ResourceConfig,
                    trackable => trackablesComposition.AddTrackable(trackable));
            }

            return CreateTracker(data, trackablesComposition, GenerateKey(data));
        }

        private static string GenerateKey(IWarehouseSlotTrackingData data)
        {
            var warehouseSlotKey = data.WarehouseConfigs
                .Select(x => x.Config.GetKey())
                .Aggregate(Path.Combine);

            var resourceKey = data.ResourceConfig.GetKey();

            return Path.Combine(warehouseSlotKey, resourceKey);
        }

        private ITrackable GetTrackable(WarehouseConfig warehouseConfig, IResourceConfig resourceConfig)
            => _warehousesContainer.TryGetItem(warehouseConfig).GetSlotTrackable(resourceConfig);

        private void GetTrackableWhenAdded(WarehouseConfig warehouseConfig,
            IResourceConfig resourceConfig, Action<ITrackable> onAdded) =>
            _warehousesContainer.GetItemWhenAdded(warehouseConfig,
                _ => onAdded?.Invoke(GetTrackable(warehouseConfig, resourceConfig)));
    }
}