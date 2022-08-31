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
        public ReadOnlyDictionary<string, ITrackable> Items => new(_items);
        
        public event Action<string, ITrackable> OnItemAdded;

        private readonly Dictionary<string, ITrackable> _items;
        
        public void AddAchievement(string key, ITrackable trackable)
        {
            if (_items.ContainsKey(key)) return;

            _items.Add(key, trackable);

            OnItemAdded?.Invoke(key, trackable);
        }
        
        public ITrackable GetAchievement(string key) =>
            _items.ContainsKey(key) ? _items[key] : null;
    }
}