using System;
using LittleBit.Modules.CoreModule;

namespace LittleBitGames.QuestsModule.Trackers
{
    [Serializable]
    public class FieldTrackable<TField> : ITrackable where TField : IConvertible
    {
        private readonly Func<TField> _getter;
        private TField _value;
        
        public FieldTrackable(Func<TField> getter, ref Action updateAction)
        {
            _getter = getter;

            updateAction += () =>
            {
                GetValue();
                OnValueChange?.Invoke(Value);
            };
        }

        private void GetValue() =>  _value = _getter.Invoke();

        public double Value => Convert.ToDouble(_value);

        public event Action<double> OnValueChange;
    }
}