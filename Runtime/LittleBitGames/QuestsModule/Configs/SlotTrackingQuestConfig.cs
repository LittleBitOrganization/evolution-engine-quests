using LittleBitGames.QuestsModule.Trackers.Metadata;
using UnityEngine;

namespace LittleBitGames.QuestsModule.Configs
{
    public abstract class SlotTrackingQuestConfig : QuestConfig, ISlotTrackingData
    {
        [field: SerializeField]
        public TrackRelativity TrackRelativity { get; private set; }

        [field: SerializeField]
        public double TargetValue { get; private set; }
    }
}