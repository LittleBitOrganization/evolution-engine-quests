using LittleBit.Modules.Description;
using LittleBitGames.QuestsModule.Common;
using LittleBitGames.QuestsModule.Trackers.Models;
using UnityEngine;

namespace LittleBitGames.QuestsModule.Configs
{
    [CreateAssetMenu(menuName = "Configs/Quests/WarehouseQuestConfig", fileName = "WarehouseQuestConfig")]
    public class WarehouseSlotSlotTrackingQuestConfig : SlotTrackingQuestConfig, IWarehouseSlotTrackingData
    {
        public IResourceConfig ResourceConfig => resourceConfig.Result;

        [SerializeField]
        private ResourceConfigInterfaceContainer resourceConfig;

        [field: SerializeField] public KeyHolder WarehouseKeyHolder { get; private set; }

        [field: SerializeField] public double TargetValue { get; private set; }
    }
}