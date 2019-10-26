using DDD.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.Domain.Events
{
    public class StudentRemovedEvent : Event
    {
        public StudentRemovedEvent(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public Guid Id { get; set; }
    }
}
