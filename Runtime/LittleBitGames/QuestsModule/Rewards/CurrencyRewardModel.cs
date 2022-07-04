using System.Collections.Generic;

namespace LittleBitGames.QuestsModule.Rewards
{
    public class CurrencyRewardModel : IRewardModel
    {
        private IReadOnlyList<RewardItem> _reward;

        public CurrencyRewardModel(CurrencyRewardData data) => _reward = data.Items;

        public void Take()
        {
            
        }
    }
}