using LittleBit.Modules.Description;
using LittleBitGames.QuestsModule.Common;
using LittleBitGames.QuestsModule.Trackers.Metadata;
using UnityEngine;

namespace LittleBitGames.QuestsModule.Configs
{
    [CreateAssetMenu(menuName = "Configs/Quests/AchievementQuestConfig", fileName = "AchievementQuestConfig")]
    public class AchievementTrackingQuestConfig : SlotTrackingQuestConfig, IAchievementSlotTrackingData
    {
        [field: SerializeField] public double TargetValue { get; private set; }

        [SerializeField] private string achievementSlotKey;
        public IKeyHolder AchievementSlotKeyHolder => new KeyHolder(achievementSlotKey);
    }
}