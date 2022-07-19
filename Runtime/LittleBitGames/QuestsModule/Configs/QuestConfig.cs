using LittleBitGames.QuestsModule.Quests.Metadata;
using LittleBitGames.QuestsModule.Rewards;
using LittleBitGames.QuestsModule.Trackers.Metadata;
using NaughtyAttributes;
using UnityEngine;

namespace LittleBitGames.QuestsModule.Configs
{
    public abstract class QuestConfig : ScriptableObject, ITrackingData
    {
        [field: SerializeField] public QuestMetadata Metadata { get; private set; }
    }
}