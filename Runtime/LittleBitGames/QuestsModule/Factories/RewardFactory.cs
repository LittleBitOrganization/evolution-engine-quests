using System;
using LittleBitGames.QuestsModule.Rewards;

namespace LittleBitGames.QuestsModule.Factories
{
    public class RewardFactory : IRewardFactory
    {
        private readonly ICreator _creator;

        public RewardFactory(ICreator creator)
            => _creator = creator;

        public IRewardModel Create<T>(T data) where T : IRewardData => data switch
        {
            CurrencyRewardData => _creator.Instantiate<CurrencyRewardModel>(data),
            _ => throw new ArgumentOutOfRangeException(nameof(data), data, null)
        };
    }
}