using DDD.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.Domain.Events
{
    public class StudentUpdatedEvent : Event
    {
        public StudentUpdatedEvent(Guid id, string name, string email, DateTime birthDate)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            AggregateId = id;
        }
        public Guid Id { get; set; }

        public string Name { get; private set; }

        public string Email { get; private set; }

        public DateTime BirthDate { get; private set; }
    }
}
