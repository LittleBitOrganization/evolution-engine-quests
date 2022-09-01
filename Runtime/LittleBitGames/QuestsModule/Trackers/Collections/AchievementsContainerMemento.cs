using System;
using LittleBit.Modules.CoreModule;
using LittleBitGames.QuestsModule.Trackers.Models;
using UnityEngine;

namespace LittleBitGames.QuestsModule.Trackers.Collections
{
    [Serializable]
    public class AchievementsContainerMemento : Data
    {
        [field: SerializeField]
        public SerializableDictionary<string, AchievementSlot> Slots { get; private set; }

        public AchievementsContainerMemento(SerializableDictionary<string, AchievementSlot> slots) =>
            Slots = slots;

        public AchievementsContainerMemento() =>
            Slots = new();
    }
}