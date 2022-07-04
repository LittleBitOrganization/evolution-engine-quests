using LittleBitGames.QuestsModule.Rewards;

namespace LittleBitGames.QuestsModule.Factories
{
    public interface IRewardFactory
    {
        IRewardModel Create<T>(T data) where T : IRewardData;
    }
}