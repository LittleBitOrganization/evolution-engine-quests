using Infrastructure.New;
using LittleBit.Modules.Description;
using LittleBitGames.QuestsModule.Trackers.Metadata;

namespace LittleBitGames.QuestsModule.Trackers.Models
{
    public interface IWarehouseSlotTrackingData : ISlotTrackingData
    {
        public IResourceConfig ResourceConfig { get; }
        
        public WarehouseConfigSO[] WarehouseConfigs { get; }
    }
}