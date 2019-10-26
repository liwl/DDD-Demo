using DDD.Domain.Core.Events;
using DDD.Infrastruct.Data.Repository.EventSourcing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.Infrastruct.Data.EventSourcing
{
    public class SqlEventStore : IEventStore
    {
        private readonly IEventStoreRepository _eventStoreRepository;
        //private readonly IUser _user;
        public SqlEventStore(IEventStoreRepository eventStoreRepository)
        {
            _eventStoreRepository = eventStoreRepository;
            //_user = user;
        }

        public void Save<T>(T theEvent) where T : Event
        {
            var serializedData = JsonConvert.SerializeObject(theEvent);

            var storedEvent = new StoredEvent(
                theEvent,
                serializedData,
                "");

            _eventStoreRepository.Store(storedEvent);
        }
    }
}
