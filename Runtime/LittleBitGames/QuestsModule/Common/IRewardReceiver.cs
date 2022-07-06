using System.Collections.Generic;
using LittleBitGames.QuestsModule.Rewards;

namespace LittleBitGames.QuestsModule.Common
{
    public interface IRewardReceiver
    {
        void TakeReward(IReadOnlyList<RewardItem> reward);
    }
}