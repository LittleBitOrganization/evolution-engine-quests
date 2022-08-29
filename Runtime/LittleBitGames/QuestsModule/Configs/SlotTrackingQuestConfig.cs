using Infrastructure.New;
using LittleBitGames.QuestsModule.Trackers.Metadata;
using LittleBitGames.QuestsModule.Trackers.ProgressCalculators;
using UnityEngine;

namespace LittleBitGames.QuestsModule.Configs
{
    public abstract class SlotTrackingQuestConfig : QuestConfig, ISlotTrackingData
    {
        [field: SerializeField]
        public TrackRelativity TrackRelativity { get; private set; }

        [field: SerializeField]
        public ProgressUpdateMethod UpdateMethod { get; private set; }

        [field: SerializeField]
        public double TargetValue { get; private set; }
    }
}