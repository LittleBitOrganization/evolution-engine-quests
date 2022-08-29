using System.IO;
using System.Linq;
using Infrastructure.New;
using LittleBit.Modules.Description;
using LittleBitGames.QuestsModule.Trackers.Models;
using NaughtyAttributes;
using UnityEngine;

namespace LittleBitGames.QuestsModule.Configs
{
    [CreateAssetMenu(menuName = "Configs/Quests/WarehouseQuestConfig", fileName = "WarehouseQuestConfig")]
    public class WarehouseSlotsTrackingQuestConfig : SlotTrackingQuestConfig, IWarehouseSlotsTrackingData
    {
        [SerializeField] private ResourceConfigInterfaceContainer resourceConfig;

        [field: SerializeField] public WarehouseConfigSO[] WarehouseConfigs { get; private set; }

        public IResourceConfig ResourceConfig => resourceConfig.Result;
        
        [Button]
        private void GenerateKey()
        {
            const string prefix = "quest/";

            var warehousesKeys = WarehouseConfigs
                .Select(w => w is null ? "missing_warehouse" : w.Config.GetKey())
                .Aggregate(Path.Combine);

            var resourceKey = ResourceConfig is null ? "missing_resource_config" : ResourceConfig.GetKey();
            
            var key = Path.Combine(prefix,
                TrackRelativity.ToString()[..3].ToLower(),
                warehousesKeys,
                resourceKey,
                TargetValue.ToString());

            Metadata.SetKey(key);
        }
    }
}