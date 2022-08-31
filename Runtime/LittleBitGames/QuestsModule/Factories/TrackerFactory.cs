using System;
using LittleBit.Modules.CoreModule;
using LittleBitGames.QuestsModule.Common;
using LittleBitGames.QuestsModule.Trackers.Controllers;
using LittleBitGames.QuestsModule.Trackers.Memento;
using LittleBitGames.QuestsModule.Trackers.Metadata;
using LittleBitGames.QuestsModule.Trackers.Models;
using LittleBitGames.QuestsModule.Trackers.ProgressCalculators;

namespace LittleBitGames.QuestsModule.Factories
{
    public abstract class TrackerFactory
    {
        protected IProgressSetter GetProgressSetter<T>(T trackingData) where T : ITrackingData =>
            trackingData.UpdateMethod switch
            {
                ProgressUpdateMethod.IncrementValue => new IncrementalProgressSetter(),
                ProgressUpdateMethod.SetCurrentValue => new CurrentValueProgressSetter(),
                _ => throw new ArgumentOutOfRangeException()
            };
    }

    public abstract class TrackerFactory<T> : TrackerFactory, ITrackerFactory<T> where T : ITrackingData
    {
        private readonly ICreator _creator;

        protected TrackerFactory(ICreator creator) => _creator = creator;

        public abstract ITrackerController Create(T data);

        protected ITrackerController CreateTracker<T>(T trackingData, ITrackable trackable)
            where T : ITrackingData
        {
            var progressSetter = GetProgressSetter(trackingData);
            var model = _creator.Instantiate<TrackerModel>(trackable, trackingData);
            var caretaker = _creator.Instantiate<TrackerModelCaretaker>(model);
            var controller = _creator.Instantiate<TrackerController>(model, progressSetter);

            return controller;
        }
    }
}