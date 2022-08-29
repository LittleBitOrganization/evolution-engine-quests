using System;
using System.Linq;
using LittleBit.Modules.CoreModule;

namespace LittleBitGames.QuestsModule.Trackers
{
    public class TrackablesComposition : ITrackable
    {
        public double Value => _trackables.Sum(t => t.Value);
        public event Action<double> OnValueChange;
        
        private readonly ITrackable[] _trackables;

        public TrackablesComposition(ITrackable[] trackables)
        {
            _trackables = trackables;

            foreach (var trackable in _trackables) trackable.OnValueChange += _ => OnValueChange?.Invoke(Value);
        }
    }
}