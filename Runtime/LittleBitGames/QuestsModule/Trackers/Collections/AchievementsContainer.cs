using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using LittleBit.Modules.CoreModule;
using LittleBitGames.QuestsModule.Trackers.Controllers;
using LittleBitGames.QuestsModule.Trackers.Models;

namespace LittleBitGames.QuestsModule.Trackers.Collections
{
    public class AchievementsContainer
    {
        public event Action<string, AchievementSlot> OnAchievementAdded;

        private readonly Dictionary<string, AchievementSlot> _slots;

        public AchievementsContainer() => _slots = new();

        public void AddAchievement(string key, AchievementSlot slot)
        {
            if (_slots.ContainsKey(key)) return;

            _slots.Add(key, slot);

            OnAchievementAdded?.Invoke(key, slot);
        }
        
        internal AchievementSlot GetAchievement(string key) =>
            _slots.ContainsKey(key) ? _slots[key] : null;
    }
}