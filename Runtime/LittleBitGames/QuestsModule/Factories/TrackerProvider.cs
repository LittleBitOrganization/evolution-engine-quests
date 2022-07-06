using System;
using System.Collections.Generic;
using LittleBitGames.QuestsModule.Trackers.Controllers;
using LittleBitGames.QuestsModule.Trackers.Metadata;

namespace LittleBitGames.QuestsModule.Factories
{
    public class TrackerProvider : ITrackerProvider
    {
        private readonly IAchievementTrackerFactory _achievementTrackerFactory;
        private readonly IEventTrackerFactory _eventTrackerFactory;
        private readonly Dictionary<ITrackingData, ITrackerController> _cachedTrackers;

        public TrackerProvider(ICreator creator)
        {
            _cachedTrackers = new();
            _achievementTrackerFactory = creator.Instantiate<AchievementTrackerFactory>();
            _eventTrackerFactory = creator.Instantiate<EventTrackerFactory>();
        }

        public ITrackerController Create<T>(T data) where T : ITrackingData
            => data switch
            {
                IEventTrackingData eventTrackerData => GetEventTracker(eventTrackerData),
                ISlotTrackingData slotTrackingData => GetAchievementTracker(slotTrackingData),
                _ => throw new ArgumentOutOfRangeException(nameof(data), data, null)
            };

        private ITrackerController GetCachedTracker(ITrackingData data)
            => _cachedTrackers.ContainsKey(data) ? _cachedTrackers[data] : null;

        private ITrackerController CreateTracker<T>(T data, ITrackerFactory<T> factory) where T : ITrackingData
        {
            var trackerController = factory.Create(data);

            _cachedTrackers.Add(data, trackerController);

            return trackerController;
        }

        private ITrackerController GetEventTracker(IEventTrackingData data) =>
            GetCachedTracker(data) ?? CreateTracker(data, _eventTrackerFactory);

        private ITrackerController GetAchievementTracker(ISlotTrackingData data) =>
            GetCachedTracker(data) ?? CreateTracker(data, _achievementTrackerFactory);
    }
}