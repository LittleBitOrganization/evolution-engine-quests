using System.Collections.Generic;

namespace LittleBitGames.QuestsModule.Quests.Metadata
{
    public interface IFormattableText
    {
        string Format(Dictionary<string, string> tags);
    
        string RawValue { get; }
    }
}