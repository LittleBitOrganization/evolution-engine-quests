using System;
using LittleBit.Modules.Description;
using UnityEngine;

namespace LittleBitGames.QuestsModule.Common
{
    [Serializable]
    public class KeyHolder : IKeyHolder
    {
        [field: SerializeField] public string Key { get; private set; }

        public KeyHolder(string key)
            => Key = key;

        public string GetKey() => Key;
    }
}