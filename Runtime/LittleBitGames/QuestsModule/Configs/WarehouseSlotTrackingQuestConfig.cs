using System.IO;
using LittleBit.Modules.Description;
using LittleBit.Modules.Warehouse.Configs;
using LittleBitGames.QuestsModule.Trackers.Models;
using NaughtyAttributes;
using UnityEngine;

namespace LittleBitGames.QuestsModule.Configs
{
    [CreateAssetMenu(menuName = "Configs/Quests/WarehouseQuestConfig", fileName = "WarehouseQuestConfig")]
    public class WarehouseSlotTrackingQuestConfig : SlotTrackingQuestConfig, IWarehouseSlotTrackingData
    {
        [SerializeField] private ResourceConfigInterfaceContainer resourceConfig;
        [SerializeField] private WarehouseConfig warehouseConfig;

        public IResourceConfig ResourceConfig => resourceConfig.Result;
        public IKeyHolder WarehouseKeyHolder => warehouseConfig;


        [Button]
        private void GenerateKey()
        {
            const string prefix = "quest/";

            var key = Path.Combine(
                prefix,
                TrackRelativity.ToString()[..3].ToLower(),
                WarehouseKeyHolder is null ? "missing_warehouse" : WarehouseKeyHolder.GetKey(),
                ResourceConfig is null ? "missing_resource_config" : ResourceConfig.GetKey(),
                TargetValue.ToString());

            Metadata.SetKey(key);
        }
    }
}