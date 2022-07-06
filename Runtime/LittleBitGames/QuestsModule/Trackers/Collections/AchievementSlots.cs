using System.Collections.Generic;
using System.Collections.ObjectModel;
using LittleBit.Modules.CoreModule;
using LittleBitGames.QuestsModule.Common;
using LittleBitGames.QuestsModule.Trackers.Models;

namespace LittleBitGames.QuestsModule.Trackers.Collections
{
    public class AchievementSlots : IReadOnlyContainer<string, AchievementSlotModel>
    {
        public ReadOnlyDictionary<string, AchievementSlotModel> Items => new(_items);

        private readonly Dictionary<string, AchievementSlotModel> _items;

        
        public AchievementSlots()
            => _items = new();

        
        public AchievementSlotModel TryGetItem(string key)
            => _items.ContainsKey(key) ? _items[key] : AddNewSlot(key);

        
        public void TryRemoveItem(string key)
        {
            if (!_items.ContainsKey(key)) return;

            _items.Remove(key);
        }
        
        private AchievementSlotModel AddNewSlot(string key)
        {
            var slot = new AchievementSlotModel(new KeyHolder(key));

            _items.Add(key, slot);

            return slot;
        }

        public void IncreaseSlotValue(string key, double value)
            => TryGetItem(key).IncreaseValue(value);

        public void SetSlotValue(string key, double value) 
            => TryGetItem(key).IncreaseValue(value);
    }
}