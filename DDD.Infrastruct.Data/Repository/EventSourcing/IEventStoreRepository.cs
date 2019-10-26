using DDD.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.Infrastruct.Data.Repository.EventSourcing
{
    public interface IEventStoreRepository : IDisposable
    {
        void Store(StoredEvent theEvent);
        IList<StoredEvent> All(Guid aggregateId);
    }
}
