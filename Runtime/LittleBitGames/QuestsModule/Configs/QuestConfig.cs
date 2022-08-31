using LittleBitGames.QuestsModule.Quests.Metadata;
using LittleBitGames.QuestsModule.Trackers.Metadata;
using LittleBitGames.QuestsModule.Trackers.ProgressCalculators;
using UnityEngine;

namespace LittleBitGames.QuestsModule.Configs
{
    public abstract class QuestConfig : ScriptableObject, ITrackingData
    {
        private const string Prefix = "quest-tracker/";
        [field: SerializeField] public QuestMetadata Metadata { get; private set; }

        public string TrackerKey => Prefix + Metadata.Key;

        [field: SerializeField]
        public double TargetValue { get; private set; }
        
        [field: SerializeField]
        public TrackRelativity TrackRelativity { get; private set; }
        
        [field: SerializeField]
        public ProgressUpdateMethod UpdateMethod { get; private set; }
    }
}