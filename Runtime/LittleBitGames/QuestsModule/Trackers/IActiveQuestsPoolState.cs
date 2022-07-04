using System.Collections.Generic;
using LittleBitGames.QuestsModule.Quests.Metadata;

namespace LittleBitGames.QuestsModule.Trackers
{
    public interface IActiveQuestsPoolState
    {
        IReadOnlyList<IQuestCategory> Categories { get; }
    }
}