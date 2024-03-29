using System.IO;
using LittleBit.Modules.Description;
using LittleBitGames.QuestsModule.Common;
using LittleBitGames.QuestsModule.Trackers.Metadata;
using NaughtyAttributes;
using UnityEngine;

namespace LittleBitGames.QuestsModule.Configs
{
    [CreateAssetMenu(menuName = "Configs/Quests/AchievementQuestConfig", fileName = "AchievementQuestConfig")]
    public class AchievementTrackingQuestConfig : QuestConfig, IAchievementTrackingData
    {
        [SerializeField] private string achievementSlotKey;
        public IKeyHolder AchievementKeyHolder => new KeyHolder(achievementSlotKey);
        
        [Button]
        private void GenerateKey()
        {
            const string prefix = "quest/";

            var key = Path.Combine(
                prefix,
                TrackRelativity.ToString()[..3].ToLower(),
                AchievementKeyHolder.GetKey(),
                TargetValue.ToString());

            Metadata.SetKey(key);
        }
    }
}