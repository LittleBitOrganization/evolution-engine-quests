using System;
using System.Collections.Generic;
using System.Linq;
using LittleBit.Modules.CoreModule;

namespace LittleBitGames.QuestsModule.Trackers
{
    public class TrackablesComposition : ITrackable
    {
        public double Value => _trackables.Sum(t => t.Value);
        public event Action<double> OnValueChange;

        private readonly List<ITrackable> _trackables;

        public TrackablesComposition(List<ITrackable> trackables)
        {
            _trackables = trackables;

            foreach (var trackable in _trackables) SubscribeToTrackable(trackable);
        }

        private void SubscribeToTrackable(ITrackable trackable) =>
            trackable.OnValueChange += _ => InvokeOnValueChange();

        private void InvokeOnValueChange() =>
            OnValueChange?.Invoke(Value);

        public TrackablesComposition() =>
            _trackables = new();

        public void AddTrackable(ITrackable trackable)
        {
            _trackables.Add(trackable);
            SubscribeToTrackable(trackable);
        }
    }
}