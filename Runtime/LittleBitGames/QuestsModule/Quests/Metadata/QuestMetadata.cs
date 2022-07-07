using System;
using NaughtyAttributes;
using UnityEngine;

namespace LittleBitGames.QuestsModule.Quests.Metadata
{
    [Serializable]
    public class QuestMetadata
    {
        [field: SerializeField] public string Key { get; private set; }

        [field: SerializeField] public RawText Name { get; private set; }

        [field: SerializeField] public RawText Description { get; private set; }

        [field: SerializeField] public QuestCategory Category { get; private set; }

        [field: SerializeField, ShowAssetPreview]
        public Sprite Icon { get; private set; }

        internal void SetKey(string key)
            => Key = key;
    }
}