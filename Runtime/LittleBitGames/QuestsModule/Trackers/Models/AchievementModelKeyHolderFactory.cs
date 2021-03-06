using System.IO;
using LittleBit.Modules.Description;
using LittleBitGames.QuestsModule.Common;
using LittleBitGames.QuestsModule.Trackers.Metadata;

namespace LittleBitGames.QuestsModule.Trackers.Models
{
    public class AchievementModelKeyHolderFactory
    {
        private const string DataNamingPrefix = "AchievementTrackerModel";

        public IKeyHolder Create(ISlotTrackingData trackingData, string trackableSlotKey)
            => new KeyHolder(Path.Combine(
                DataNamingPrefix,
                trackingData.TrackRelativity.ToString(),
                trackableSlotKey,
                trackingData.TargetValue.ToString()));
    }
}