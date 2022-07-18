using System.IO;
using Infrastructure.New;
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
        [SerializeField] private WarehouseConfigSO warehouseConfig;

        public IResourceConfig ResourceConfig => resourceConfig.Result;
        public WarehouseConfig WarehouseConfig => warehouseConfig.Config;


        [Button]
        private void GenerateKey()
        {
            const string prefix = "quest/";

            var key = Path.Combine(
                prefix,
                TrackRelativity.ToString()[..3].ToLower(),
                WarehouseConfig is null ? "missing_warehouse" : WarehouseConfig.GetKey(),
                ResourceConfig is null ? "missing_resource_config" : ResourceConfig.GetKey(),
                TargetValue.ToString());

            Metadata.SetKey(key);
        }
    }
}