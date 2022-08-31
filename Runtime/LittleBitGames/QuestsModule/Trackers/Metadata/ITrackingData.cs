using LittleBitGames.QuestsModule.Trackers.ProgressCalculators;

namespace LittleBitGames.QuestsModule.Trackers.Metadata
{
    public interface ITrackingData
    {
        public string TrackerKey { get; }
        
        public double TargetValue { get; }
        
        public TrackRelativity TrackRelativity { get; }
        
        public ProgressUpdateMethod UpdateMethod { get; }
    }
}