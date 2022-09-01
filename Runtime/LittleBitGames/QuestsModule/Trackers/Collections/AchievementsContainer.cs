using System;
using System.Collections.Generic;
using System.Linq;
using LittleBit.Modules.CoreModule;
using LittleBitGames.QuestsModule.Trackers.Models;

namespace LittleBitGames.QuestsModule.Trackers.Collections
{
    public class AchievementsContainer : IOriginator<AchievementsContainerMemento>
    {
        public event Action<string, AchievementSlot> OnAchievementAdded;

        private SerializableDictionary<string, AchievementSlot> _slots;

        internal IReadOnlyList<AchievementSlot> Slots => _slots.Values.ToList();

        public AchievementsContainer() => _slots = new();

        public AchievementSlot AddAchievement(string key)
        {
            if (_slots.ContainsKey(key)) return _slots[key];

            var slot = new AchievementSlot();
            
            _slots.Add(key, slot);

            OnAchievementAdded?.Invoke(key, slot);

            return slot;
        }

        internal AchievementSlot GetAchievement(string key) =>
            _slots.ContainsKey(key) ? _slots[key] : null;

        public AchievementsContainerMemento Backup() => new(_slots);

        public void Restore(AchievementsContainerMemento data) => _slots = data.Slots;
    }
}