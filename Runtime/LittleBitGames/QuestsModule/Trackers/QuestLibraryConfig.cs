using System.Collections.Generic;
using LittleBitGames.QuestsModule.Configs;
using UnityEngine;

namespace LittleBitGames.QuestsModule.Trackers
{
    [CreateAssetMenu(fileName = "QuestLibraryConfig", menuName = "Configs/Quests/QuestLibraryConfig")]
    public class QuestLibraryConfig : ScriptableObject
    {
        [SerializeField] private List<QuestConfig> questConfigs;

        public IReadOnlyList<QuestConfig> QuestConfigs => questConfigs;
    }
}