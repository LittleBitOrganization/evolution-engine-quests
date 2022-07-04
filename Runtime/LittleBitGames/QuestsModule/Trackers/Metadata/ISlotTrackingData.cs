namespace LittleBitGames.QuestsModule.Trackers.Metadata
{
    public interface ISlotTrackingData : ITrackingData
    {
        public double TargetValue { get; }
        
        public TrackRelativity TrackRelativity { get; }
    }
}