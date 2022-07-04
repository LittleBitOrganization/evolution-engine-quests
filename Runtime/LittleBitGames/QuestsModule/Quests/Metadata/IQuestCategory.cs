using System;

namespace LittleBitGames.QuestsModule.Quests.Metadata
{
    public interface IQuestCategory : IEquatable<IQuestCategory>
    {
        string Name { get; }
    }
}