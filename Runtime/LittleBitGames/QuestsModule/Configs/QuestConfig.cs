using LittleBitGames.QuestsModule.Quests.Metadata;
using LittleBitGames.QuestsModule.Rewards;
using LittleBitGames.QuestsModule.Trackers.Metadata;
using LittleBitGames.QuestsModule.Trackers.ProgressCalculators;
using NaughtyAttributes;
using UnityEngine;

namespace LittleBitGames.QuestsModule.Configs
{
    public abstract class QuestConfig : ScriptableObject, ISlotTrackingData
    {
        [field: SerializeField] public QuestMetadata Metadata { get; private set; }
        
        [field: SerializeField]
        public double TargetValue { get; private set; }
        
        [field: SerializeField]
        public TrackRelativity TrackRelativity { get; private set; }
        
        [field: SerializeField]
        public ProgressUpdateMethod UpdateMethod { get; private set; }
    }
}