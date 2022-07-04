using System;
using LittleBit.Modules.Description.ResourceGenerator;
using UnityEngine;

namespace LittleBitGames.QuestsModule.Rewards
{
    [Serializable]
    public class RewardItem
    {
        [field: SerializeField]
        public ResourceConfig ResourceConfig { get; private set; }
        
        [field: SerializeField]
        public double Value { get; private set; }
    }
}