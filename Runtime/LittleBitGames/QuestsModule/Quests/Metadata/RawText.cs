using System;
using System.Collections.Generic;
using System.Linq;
using NaughtyAttributes;
using UnityEngine;

namespace LittleBitGames.QuestsModule.Quests.Metadata
{
    [Serializable]
    public class RawText : IFormattableText
    {
        [field: SerializeField, ResizableTextArea] public string RawValue { get; private set; }

        public string Format(Dictionary<string, string> tags)
            => tags.ToList().Aggregate(RawValue, (current, value)
                => current.Replace(value.Key, value.Value));
    }
}