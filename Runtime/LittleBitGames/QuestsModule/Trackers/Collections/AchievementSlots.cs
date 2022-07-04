using System.Collections.Generic;
using System.Collections.ObjectModel;
using LittleBit.Modules.CoreModule;
using LittleBitGames.QuestsModule.Common;
using LittleBitGames.QuestsModule.Trackers.Models;

namespace LittleBitGames.QuestsModule.Trackers.Collections
{
    public class AchievementSlots : IReadOnlyContainer<string, ITrackable>
    {
        public ReadOnlyDictionary<string, ITrackable> Items => new(_items);

        private readonly Dictionary<string, ITrackable> _items;

        public AchievementSlots()
            => _items = new();

        public ITrackable TryGetItem(string key)
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
    }
}