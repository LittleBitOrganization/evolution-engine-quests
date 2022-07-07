using LittleBitGames.QuestsModule.Trackers.Metadata;
using UnityEngine;

namespace LittleBitGames.QuestsModule.Configs
{
    public abstract class SlotTrackingQuestConfig : QuestConfig, ISlotTrackingData
    {
        [field: SerializeField]
        public TrackRelativity TrackRelativity { get; private set; }

        public double TargetValue { get; }
    }
}