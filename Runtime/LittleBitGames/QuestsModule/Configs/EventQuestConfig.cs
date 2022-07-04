using LittleBitGames.QuestsModule.Quests;
using LittleBitGames.QuestsModule.Trackers.Metadata;
using UnityEngine;

namespace LittleBitGames.QuestsModule.Configs
{
    [CreateAssetMenu(menuName = "Configs/Quests/EventQuestConfig", fileName = "EventQuestConfig")]
    public class EventQuestConfig : QuestConfig, IEventTrackingData
    {
        [field: SerializeField]
        public QuestEventData QuestEventData { get; set; }
    }
}