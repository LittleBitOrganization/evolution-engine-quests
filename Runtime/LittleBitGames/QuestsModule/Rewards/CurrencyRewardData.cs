using System;
using System.Collections.Generic;
using UnityEngine;

namespace LittleBitGames.QuestsModule.Rewards
{
    [Serializable]
    public class CurrencyRewardData : IRewardData
    {
        [SerializeField] private List<RewardItem> items;

        public IReadOnlyList<RewardItem> Items => items;
    }
}