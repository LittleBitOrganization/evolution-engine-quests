using LittleBitGames.QuestsModule.Quests.Controllers;
using LittleBitGames.QuestsModule.Quests.Metadata;
using LittleBitGames.QuestsModule.Trackers;

namespace LittleBitGames.QuestsModule.Extensions
{
    public static class QuestExtensions
    {
        public static PooledQuest AsPooledQuest(this IQuestController controller, IQuestCategory category,
            int indexInPool) => new(controller, category, indexInPool);
    }
}