using LittleBitGames.QuestsModule.Configs;
using LittleBitGames.QuestsModule.Quests.Controllers;

namespace LittleBitGames.QuestsModule.Factories
{
    public interface IQuestFactory
    {
        IQuestController Create<T>(T config) where T : QuestConfig;
    }
}