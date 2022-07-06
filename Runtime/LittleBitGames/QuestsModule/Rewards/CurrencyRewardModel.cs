using System.Collections.Generic;
using LittleBitGames.QuestsModule.Common;

namespace LittleBitGames.QuestsModule.Rewards
{
    public class CurrencyRewardModel : IRewardModel
    {
        private readonly IReadOnlyList<RewardItem> _reward;
        private readonly IRewardReceiver _receiver;

        public CurrencyRewardModel(CurrencyRewardData data, IRewardReceiver receiver)
        {
            _receiver = receiver;
            _reward = data.Items;
        }

        public void Take()
            => _receiver.TakeReward(_reward);
    }
}