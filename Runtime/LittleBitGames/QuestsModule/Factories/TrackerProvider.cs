using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using LittleBitGames.QuestsModule.Trackers.Controllers;
using LittleBitGames.QuestsModule.Trackers.Metadata;

namespace LittleBitGames.QuestsModule.Factories
{
    public class TrackerProvider : ITrackerProvider
    {
        private readonly Dictionary<Type, object> _trackerFactories;
        private readonly MethodInfo _createMethod;

        public TrackerProvider(Dictionary<Type, object> trackerFactories)
        {
            _trackerFactories = trackerFactories;
            _createMethod = GetType().GetMethod(nameof(CreateControllerUsingFactory));
        }

        public ITrackerController Create(ISlotTrackingData data)
        {
            var dataType = data.GetType().GetInterfaces().Where(t => t != typeof(ISlotTrackingData))!.First();

            return !_trackerFactories.ContainsKey(dataType) ? null : InvokeCreateMethod(data, dataType);
        }

        private ITrackerController InvokeCreateMethod(ISlotTrackingData data, Type dataType)
        {
            var genericMethod = _createMethod.MakeGenericMethod(dataType);

            return (ITrackerController) genericMethod.Invoke(this, new object[] {data});
        }

        private ITrackerController CreateControllerUsingFactory<TData>(ISlotTrackingData data) =>
            ((ITrackerFactory<TData>) _trackerFactories[data.GetType()]).Create((TData) data);
    }
}