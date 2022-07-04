using System.Collections.Generic;

namespace LittleBitGames.QuestsModule.Quests.Metadata
{
    public interface IQuestDescription
    {
        string Format(Dictionary<string, string> tags);
    
        string RawValue { get; }
    }
}