using System;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace LittleBitGames.QuestsModule.Quests.Metadata
{
    [Serializable]
    public class QuestCategory : IQuestCategory
    {
        public QuestCategory(string name) => Name = name;
    
        [field: SerializeField] public string Name { get; private set; }

        public bool Equals([DisallowNull] IQuestCategory other) => other!.Name.Equals(Name);
    }
}