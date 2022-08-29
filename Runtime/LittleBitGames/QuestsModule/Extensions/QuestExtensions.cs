using LittleBit.Modules.Description;
using LittleBitGames.QuestsModule.Configs;
using LittleBitGames.QuestsModule.Quests.Controllers;
using LittleBitGames.QuestsModule.Trackers;

namespace LittleBitGames.QuestsModule.Extensions
{
    public static class QuestExtensions
    {
        public static PooledQuest AsPooledQuest(this IQuestController controller, QuestConfig config,
            IKeyHolder keyHolder, int indexInPool) => new(controller, config, keyHolder, indexInPool);
    }
}