using System;

namespace LittleBitGames.QuestsModule.Quests
{
    public interface IQuestEventData : IEquatable<QuestEventData>
    {
        string Name { get; set; }
    }
}