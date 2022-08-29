using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using LittleBit.Modules.CoreModule;
using LittleBitGames.QuestsModule.Common;
using LittleBitGames.QuestsModule.Trackers.Models;

namespace LittleBitGames.QuestsModule.Trackers.Collections
{
    public class AchievementSlots : IReadOnlyContainer<string, AchievementSlotModel>
    {
        private const string Prefix = "achievement/";
        public ReadOnlyDictionary<string, AchievementSlotModel> Items => new(_items);
        public event Action<string, AchievementSlotModel> OnItemAdded;

        private readonly Dictionary<string, AchievementSlotModel> _items;
        
        public AchievementSlots()
            => _items = new();

        
        private string FormatKey(string key) =>
            $"{Prefix}{key}";

        public AchievementSlotModel TryGetItem(string key)
        {
            var formattedKey = FormatKey(key);
            
            return _items.ContainsKey(formattedKey) ? _items[formattedKey] : AddNewSlot(formattedKey);
        }

        public void GetItemWhenAdded(string key, Action<AchievementSlotModel> onAdded)
        {
            if (_items.ContainsKey(key))
            {
                onAdded?.Invoke(_items[key]);
                return;
            }

            OnItemAdded += (id, slot) =>
            {
                if (id != key) return;
                
                onAdded?.Invoke(slot);
            };
        }

        public void TryRemoveItem(string key)
        {
            var formattedKey = FormatKey(key);
            
            if (!_items.ContainsKey(formattedKey)) return;

            _items.Remove(formattedKey);
        }

        private AchievementSlotModel AddNewSlot(string key)
        {
            var slot = new AchievementSlotModel(new KeyHolder(key));

            _items.Add(key, slot);
            
            OnItemAdded?.Invoke(key, slot);

            return slot;
        }

        public void IncreaseSlotValue(string key, double value)
            => TryGetItem(key).IncreaseValue(value);

        public void SetSlotValue(string key, double value)
            => TryGetItem(key).IncreaseValue(value);
    }
}