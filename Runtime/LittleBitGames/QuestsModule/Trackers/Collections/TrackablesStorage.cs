using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using LittleBit.Modules.CoreModule;
using LittleBitGames.QuestsModule.Trackers.Models;

namespace LittleBitGames.QuestsModule.Trackers.Collections
{
    public class TrackablesStorage : IReadOnlyContainer<string, ITrackable>
    {
        private const string Prefix = "achievement/";
        public ReadOnlyDictionary<string, ITrackable> Items => new(_items);
        public event Action<string, ITrackable> OnItemAdded;

        private readonly Dictionary<string, ITrackable> _items;
        
        public TrackablesStorage()
            => _items = new();
        
        private string FormatKey(string key) =>
            $"{Prefix}{key}";

        public ITrackable TryGetItem(string key)
        {
            var formattedKey = FormatKey(key);
            
            return _items.ContainsKey(formattedKey) ? _items[formattedKey] : null;
        }

        public void GetItemWhenAdded(string key, Action<ITrackable> onAdded)
        {
            var formattedKey = FormatKey(key);

            if (_items.ContainsKey(formattedKey))
            {
                onAdded?.Invoke(_items[formattedKey]);
                return;
            }

            OnItemAdded += (id, slot) =>
            {
                if (id != formattedKey) return;
                
                onAdded?.Invoke(slot);
            };
        }

        public void TryRemoveItem(string key)
        {
            var formattedKey = FormatKey(key);
            
            if (!_items.ContainsKey(formattedKey)) return;

            _items.Remove(formattedKey);
        }

        public void AddNewTrackable(string key, ITrackable trackable)
        {
            var formattedKey = FormatKey(key);
            
            if(_items.ContainsKey(formattedKey)) return;

            _items.Add(formattedKey, trackable);
            
            OnItemAdded?.Invoke(formattedKey, trackable);
        }

        public ITrackable AddNewAchievement(string key) =>
            new AchievementSlotModel();
    }
}