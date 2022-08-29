namespace LittleBitGames.QuestsModule.Trackers.ProgressCalculators
{
    public enum ProgressUpdateMethod
    {
        IncrementValue = 1 << 0,
        SetCurrentValue = 1 << 1,
        SetValuesDelta = 1 << 2
    }
}