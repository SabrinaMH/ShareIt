﻿using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Akka.Event;
using Akka.Persistence.Snapshot;
using Akka.Serialization;
using EventStore.ClientAPI;
using Newtonsoft.Json;

namespace Akka.Persistence.EventStore.Snapshot
{
    public class EventStoreSnapshotStore : SnapshotStore
    {
        private readonly IEventStoreConnection _connection;

        private readonly Serializer _serializer;
        private readonly ILoggingAdapter _log;

        public EventStoreSnapshotStore()
        {
            _log = Context.GetLogger();

            var serialization = Context.System.Serialization;
            _serializer = serialization.FindSerializerForType(typeof(SelectedSnapshot));

            var extension = EventStorePersistence.Instance.Apply(Context.System);
            _connection = extension.ServerSettings.Connection;
        }

        protected override async Task<SelectedSnapshot> LoadAsync(string persistenceId, SnapshotSelectionCriteria criteria)
        {
            var streamName = GetStreamName(persistenceId);
            var slice = await _connection.ReadStreamEventsBackwardAsync(streamName, StreamPosition.End, 1, false);

            if (slice.Status == SliceReadStatus.StreamNotFound)
            {
                await _connection.SetStreamMetadataAsync(streamName, ExpectedVersion.Any, StreamMetadata.Data);
                return null;
            }

            if (slice.Events.Any())
            {
                _log.Debug("Found snapshot of {0}", persistenceId);
                var @event = slice.Events.First().OriginalEvent;
                return (SelectedSnapshot)_serializer.FromBinary(@event.Data, typeof(SelectedSnapshot));
            }

            return null;
        }

        protected override async Task SaveAsync(SnapshotMetadata metadata, object snapshot)
        {
            var streamName = GetStreamName(metadata.PersistenceId);
            var data = _serializer.ToBinary(new SelectedSnapshot(metadata, snapshot));
            var eventData = new EventData(Guid.NewGuid(), typeof(Serialization.Snapshot).Name, false, data, new byte[0]);

            await _connection.AppendToStreamAsync(streamName, ExpectedVersion.Any, eventData);
        }

        protected override void Saved(SnapshotMetadata metadata)
        { }

        protected override Task DeleteAsync(SnapshotMetadata metadata)
        {
            throw new NotImplementedException();
        }

        protected override Task DeleteAsync(string persistenceId, SnapshotSelectionCriteria criteria)
        {
            throw new NotImplementedException();
        }

        private static string GetStreamName(string persistenceId)
        {
            return string.Format("snapshot-{0}", persistenceId);
        }

        public class StreamMetadata
        {
            [JsonProperty("$maxCount")]
            public int MaxCount = 1;

            private StreamMetadata()
            {
            }

            private static readonly StreamMetadata Instance = new StreamMetadata();

            public static byte[] Data
            {
                get
                {
                    return Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(Instance));
                }
            }
        }
    }
}