using System;
using LittleBit.Modules.CoreModule;
using LittleBitGames.QuestsModule.Trackers.Models;

namespace LittleBitGames.QuestsModule.Trackers.Collections
{
    [Serializable]
    public class AchievementsContainerMemento : Data
    {
        public readonly SerializableDictionary<string, AchievementSlot> Slots;

        public AchievementsContainerMemento(SerializableDictionary<string, AchievementSlot> slots) =>
            Slots = slots;

        public AchievementsContainerMemento() =>
            Slots = new();
    }
}