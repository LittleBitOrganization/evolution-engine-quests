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
    public class WarehouseTrackerFactory : TrackerFactory<IWarehouseTrackingData>
    {
        private readonly IWarehousesContainer _warehousesContainer;

        public WarehouseTrackerFactory(ICreator creator, IWarehousesContainer warehousesContainer) : base(creator) =>
            _warehousesContainer = warehousesContainer;

        public override ITrackerController Create(IWarehouseTrackingData data)
        {
            var filteredConfigs = data.WarehouseConfigs
                .Where(x => x)
                .Select(x => x.Config);

            var trackablesComposition = 
                new CompositeTrackable(list => list.Sum(t => t.Value));

            foreach (var config in filteredConfigs)
                GetTrackableWhenAdded(config, data.ResourceConfig, trackable => trackablesComposition.AddTrackable(trackable));

            return CreateTracker(data, trackablesComposition);
        }

        private ITrackable GetTrackable(WarehouseConfig warehouseConfig, IResourceConfig resourceConfig)
            => _warehousesContainer.TryGetItem(warehouseConfig).GetSlotTrackable(resourceConfig);

        private void GetTrackableWhenAdded(WarehouseConfig warehouseConfig,
            IResourceConfig resourceConfig, Action<ITrackable> onAdded) =>
            _warehousesContainer.GetItemWhenAdded(warehouseConfig,
                _ => onAdded?.Invoke(GetTrackable(warehouseConfig, resourceConfig)));
    }
}