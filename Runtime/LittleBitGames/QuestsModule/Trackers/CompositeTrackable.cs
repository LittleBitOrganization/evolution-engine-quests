using System;
using System.Collections.Generic;
using System.Linq;
using LittleBit.Modules.CoreModule;

namespace LittleBitGames.QuestsModule.Trackers
{
    public class CompositeTrackable : ITrackable
    {
        public double Value => _valueFunc.Invoke(_trackables);
        public event Action<double> OnValueChange;

        private readonly List<ITrackable> _trackables;
        private readonly Func<List<ITrackable>, double> _valueFunc;

        public CompositeTrackable(Func<List<ITrackable>, double> valueFunc) =>
            (_valueFunc, _trackables) = (valueFunc, new());

        private void SubscribeToTrackable(ITrackable trackable) =>
            trackable.OnValueChange += _ => InvokeOnValueChange();

        private void InvokeOnValueChange() =>
            OnValueChange?.Invoke(Value);

        public void AddTrackable(ITrackable trackable)
        {
            _trackables.Add(trackable);
            OnValueChange?.Invoke(Value);
            SubscribeToTrackable(trackable);
        }
    }
}