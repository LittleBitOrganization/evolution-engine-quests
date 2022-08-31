using System;
using LittleBit.Modules.CoreModule;
using LittleBitGames.QuestsModule.Trackers.Controllers;
using LittleBitGames.QuestsModule.Trackers.Memento;
using LittleBitGames.QuestsModule.Trackers.Metadata;
using LittleBitGames.QuestsModule.Trackers.Models;
using LittleBitGames.QuestsModule.Trackers.ProgressCalculators;

namespace LittleBitGames.QuestsModule.Factories
{
    public abstract class TrackerFactory
    {
        protected IProgressSetter GetProgressSetter<T>(T trackingData) where T : ISlotTrackingData =>
            trackingData.UpdateMethod switch
            {
                ProgressUpdateMethod.IncrementValue => new IncrementalProgressSetter(),
                ProgressUpdateMethod.SetCurrentValue => new CurrentValueProgressSetter(),
                _ => throw new ArgumentOutOfRangeException()
            };
    }

    public abstract class TrackerFactory<T> : TrackerFactory, ITrackerFactory<T> where T : ISlotTrackingData
    {
        private readonly AchievementSlotKeyFactory _keyFactory;
        private readonly ICreator _creator;

        protected TrackerFactory(AchievementSlotKeyFactory keyFactory, ICreator creator) =>
            (_keyFactory, _creator) = (keyFactory, creator);

        public abstract ITrackerController Create(T data);

        protected ITrackerController CreateTracker<T>(T trackingData, ITrackable trackable, string trackableKey)
            where T : ISlotTrackingData
        {
            var keyHolder = _keyFactory.Create(trackingData, trackableKey);

            var progressSetter = GetProgressSetter(trackingData);
            var model = _creator.Instantiate<AchievementTrackerModel>(trackable, trackingData, keyHolder);
            var caretaker = _creator.Instantiate<AchievementTrackerModelCaretaker>(model);
            var controller = _creator.Instantiate<AchievementTrackerController>(model, progressSetter);

            return controller;
        }
    }
}