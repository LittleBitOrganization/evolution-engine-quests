using System;
using System.Linq.Expressions;
using LittleBit.Modules.CoreModule;

namespace LittleBitGames.QuestsModule.Trackers
{
    [Serializable]
    public class FieldTrackable<TParent, TField> : ITrackable where TField : IConvertible
    {
        private readonly Func<TParent, TField> _getter;
        private readonly TParent _parent;
        
        public FieldTrackable(
            TParent parent, 
            Expression<Func<TParent, TField>> getter, 
            ref Action updateAction)
        {
            _parent = parent;
            _getter = getter.Compile();

            updateAction += () => OnValueChange?.Invoke(GetValue());
        }

        private double GetValue() => Convert.ToDouble(_getter.Invoke(_parent));

        public double Value => GetValue();

        public event Action<double> OnValueChange;
    }
}