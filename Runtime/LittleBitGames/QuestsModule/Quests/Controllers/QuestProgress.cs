using System;

namespace LittleBitGames.QuestsModule.Quests.Controllers
{
    public class QuestProgress : Tuple<double, double>
    {
        public double CurrentValue { get; set; }
        public double TargetValue { get; set; }

        public QuestProgress(double currentValue, double targetValue) : base(currentValue, targetValue)
        {
            CurrentValue = currentValue;
            TargetValue = targetValue;
        }

        public ReadOnlyQuestProgress AsReadOnly()
            => new(CurrentValue, TargetValue);
    }
}