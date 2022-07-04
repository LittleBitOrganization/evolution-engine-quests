using System;
using NaughtyAttributes;
using UnityEngine;

namespace LittleBitGames.QuestsModule.Quests.Metadata
{
    [Serializable]
    public class QuestMetadata
    {
        [field: SerializeField]
        public string Key { get; private set; }

        [field: SerializeField]
        public string Name { get; private set; }

        [field: SerializeField]
        public QuestDescription Description { get; private set; }
    
        [field: SerializeField]
        public QuestCategory Category { get; private set; }

        [field: SerializeField, ShowAssetPreview]
        public Sprite Icon { get; private set; }
    }
}