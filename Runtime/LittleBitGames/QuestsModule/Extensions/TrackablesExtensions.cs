using LittleBit.Modules.CoreModule;
using LittleBitGames.QuestsModule.Trackers;

namespace LittleBitGames.QuestsModule.Extensions
{
    public static class TrackablesExtensions
    {
        public static TrackablesComposition AggregateToComposition(this ITrackable[] trackables) => new(trackables);
    }
}