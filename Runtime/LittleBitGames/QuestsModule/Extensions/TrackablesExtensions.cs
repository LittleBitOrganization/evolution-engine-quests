using System.Collections.Generic;
using LittleBit.Modules.CoreModule;
using LittleBitGames.QuestsModule.Trackers;

namespace LittleBitGames.QuestsModule.Extensions
{
    public static class TrackablesExtensions
    {
        public static TrackablesComposition AggregateToComposition(this List<ITrackable> trackables) => new(trackables);
    }
}