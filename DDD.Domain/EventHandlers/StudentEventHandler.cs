using DDD.Domain.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DDD.Domain.EventHandlers
{
    public class StudentEventHandler :
          INotificationHandler<StudentRegisteredEvent>,
          INotificationHandler<StudentUpdatedEvent>,
          INotificationHandler<StudentRemovedEvent>
    {
        public Task Handle(StudentUpdatedEvent message, CancellationToken cancellationToken)
        {
            // Send some notification e-mail

            return Task.CompletedTask;
        }

        public Task Handle(StudentRegisteredEvent message, CancellationToken cancellationToken)
        {
            // Send some greetings e-mail

            return Task.CompletedTask;
        }

        public Task Handle(StudentRemovedEvent message, CancellationToken cancellationToken)
        {
            // Send some see you soon e-mail

            return Task.CompletedTask;
        }
    }
}
