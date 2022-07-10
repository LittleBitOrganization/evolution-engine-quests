namespace LittleBitGames.QuestsModule.Quests.Controllers
{
    public class ReadOnlyQuestProgress : QuestProgress
    {
        public double CurrentValue { get; }
        public double TargetValue { get; }

        public ReadOnlyQuestProgress(double currentValue, double targetValue) : base(currentValue, targetValue)
        {
            CurrentValue = currentValue;
            TargetValue = targetValue;
        }
    }
}