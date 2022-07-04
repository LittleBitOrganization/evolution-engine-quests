using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

namespace LittleBitGames.QuestsModule.Collections
{
    [Serializable]
    public class ReadOnlySerializableDictionary<T1, T2>
    {
        [SerializeField] private SerializableDictionary<T1, T2> value;
        
        public IReadOnlyDictionary<T1, T2> Value => new ReadOnlyDictionary<T1, T2>(value);

        public ReadOnlySerializableDictionary(IDictionary<T1, T2> origin)
        {
            value = new SerializableDictionary<T1, T2>();
            value.CopyFrom(origin);
        }

        public ReadOnlySerializableDictionary()
            => value = new SerializableDictionary<T1, T2>();
    }
}