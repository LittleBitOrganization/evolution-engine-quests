using System.Collections.Generic;

namespace LittleBitGames.QuestsModule.Rewards
{
    public interface IRewardData
    {
        IReadOnlyList<RewardItem> Items { get; }
    }
}