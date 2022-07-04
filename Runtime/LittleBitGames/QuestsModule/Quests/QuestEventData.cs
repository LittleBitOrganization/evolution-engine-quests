using System;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace LittleBitGames.QuestsModule.Quests
{
    [Serializable]
    public class QuestEventData : IQuestEventData
    {
        [field: SerializeField] public string Name { get; set; }
    
        public bool Equals([DisallowNull] QuestEventData other) => Name == other!.Name;

        public QuestEventData(string name) 
            => Name = name;
    }
}