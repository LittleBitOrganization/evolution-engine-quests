using LittleBitGames.QuestsModule.Common;
using LittleBitGames.QuestsModule.Configs;
using LittleBitGames.QuestsModule.Quests.Controllers;
using LittleBitGames.QuestsModule.Quests.Models;

namespace LittleBitGames.QuestsModule.Factories
{
    public class QuestFactory : IQuestFactory
    {
        private readonly ICreator _creator;
        private readonly IRewardFactory _rewardFactory;
        private readonly ITrackerProvider _trackerFactory;
        
        public QuestFactory(ICreator creator, ITrackerProvider trackerProvider)
        {
            _creator = creator;
            _rewardFactory = new RewardFactory(creator);
            _trackerFactory = trackerProvider;
        }

        public IQuestController Create<T>(T config) where T : QuestConfig
        {
            var keyHolder = _creator.Instantiate<KeyHolder>(config.Metadata.Key);
            var rewardModel = _rewardFactory.Create(config.Metadata.RewardData);
            var goalTracker = _trackerFactory.Create(config);
            
            var model = _creator.Instantiate<QuestModel>(
                keyHolder,
                rewardModel,
                goalTracker);

            var controller =
                _creator.Instantiate<QuestController>(model);

            goalTracker.StartTracking();
            
            return controller;
        }
    }
}