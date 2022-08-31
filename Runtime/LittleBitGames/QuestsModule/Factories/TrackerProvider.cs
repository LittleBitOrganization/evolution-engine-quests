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
        private readonly Dictionary<string, ITrackerController> _cachedControllers;

        public TrackerProvider(Dictionary<Type, object> trackerFactories)
        {
            _cachedControllers = new();
            _trackerFactories = trackerFactories;
            _createMethod = GetType().GetMethod(nameof(CreateControllerUsingFactory),  BindingFlags.NonPublic | BindingFlags.Instance);
        }

        public ITrackerController Create(ITrackingData data)
        {
            var trackerKey = data.TrackerKey;
            
            if (_cachedControllers.ContainsKey(trackerKey)) return _cachedControllers[trackerKey];

            var dataType = data.GetType().GetInterfaces().Where(t => t != typeof(ITrackingData))!.First();

            return !_trackerFactories.ContainsKey(dataType) ? null : InvokeCreateMethod(data, dataType);
        }

        private ITrackerController InvokeCreateMethod(ITrackingData data, Type dataType)
        {
            var genericMethod = _createMethod.MakeGenericMethod(dataType);

            return (ITrackerController) genericMethod.Invoke(this, new object[] {data, dataType});
        }

        private ITrackerController CreateControllerUsingFactory<TData>(ITrackingData data, Type dataType)
        {
            var controller = ((ITrackerFactory<TData>) _trackerFactories[dataType]).Create((TData) data);
            
            _cachedControllers.Add(data.TrackerKey, controller);
            
            return controller;
        }
    }
}