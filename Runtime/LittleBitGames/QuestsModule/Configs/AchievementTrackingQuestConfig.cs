using System.IO;
using LittleBit.Modules.Description;
using LittleBit.Modules.Description.ResourceGenerator;
using LittleBitGames.QuestsModule.Common;
using LittleBitGames.QuestsModule.Trackers.Metadata;
using NaughtyAttributes;
using UnityEngine;

namespace LittleBitGames.QuestsModule.Configs
{
    [CreateAssetMenu(menuName = "Configs/Quests/AchievementQuestConfig", fileName = "AchievementQuestConfig")]
    public class AchievementTrackingQuestConfig : SlotTrackingQuestConfig, IAchievementSlotTrackingData
    {
        [SerializeField] private string achievementSlotKey;
        public IKeyHolder AchievementSlotKeyHolder => new KeyHolder(achievementSlotKey);

        [Button]
        private void GenerateKey()
        {
            const string prefix = "quest/";

            var key = Path.Combine(
                prefix,
                TrackRelativity.ToString()[..3].ToLower(),
                AchievementSlotKeyHolder.GetKey(),
                TargetValue.ToString());

            Metadata.SetKey(key);
        }
    }
}