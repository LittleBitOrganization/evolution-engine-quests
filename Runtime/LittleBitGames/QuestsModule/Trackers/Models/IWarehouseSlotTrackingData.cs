using LittleBit.Modules.Description;
using LittleBitGames.QuestsModule.Common;
using LittleBitGames.QuestsModule.Trackers.Metadata;

namespace LittleBitGames.QuestsModule.Trackers.Models
{
    public interface IWarehouseSlotTrackingData : ISlotTrackingData
    {
        public IResourceConfig ResourceConfig { get; }
        public IKeyHolder WarehouseKeyHolder { get; }
    }
}