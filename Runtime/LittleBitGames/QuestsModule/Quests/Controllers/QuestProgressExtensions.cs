namespace LittleBitGames.QuestsModule.Quests.Controllers
{
    public static class QuestProgressExtensions
    {
        public static bool HasGoalBeenReached(this QuestProgress p)
            => p.TargetValue >= p.CurrentValue;
    }
}