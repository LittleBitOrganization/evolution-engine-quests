using LittleBit.Modules.Description;
using LittleBitGames.QuestsModule.Quests.Controllers;
using LittleBitGames.QuestsModule.Quests.Metadata;
using LittleBitGames.QuestsModule.Trackers;

namespace LittleBitGames.QuestsModule.Extensions
{
    public static class QuestExtensions
    {
        public static PooledQuest AsPooledQuest(this IQuestController controller, QuestMetadata metadata,
            IKeyHolder keyHolder, int indexInPool) => new(controller, metadata, keyHolder, indexInPool);
    }
}