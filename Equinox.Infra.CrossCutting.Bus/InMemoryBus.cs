using DDD.Domain.Core.Bus;
using DDD.Domain.Core.Commands;
using DDD.Domain.Core.Events;
using MediatR;
using System;
using System.Threading.Tasks;

namespace DDD.Infra.CrossCutting.Bus
{
    /// <summary>
    /// 一个密封类，实现我们的中介记忆总线
    /// </summary>
    public sealed class InMemoryBus : IMediatorHandler
    {
        //构造函数注入
        private readonly IMediator _mediator;
        private readonly IEventStore _eventStore;

        public InMemoryBus(IEventStore eventStore, IMediator mediator)
        {
            _eventStore = eventStore;
            _mediator = mediator;
        }

        /// <summary>
        /// 实现我们在IMediatorHandler中定义的接口
        /// 没有返回值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="command"></param>
        /// <returns></returns>
        public Task SendCommand<T>(T command) where T : Command
        {
            return _mediator.Send(command);//这里要注意下 command 对象
        }

        /// <summary>
        /// 引发事件的实现方法
        /// </summary>
        /// <typeparam name="T">泛型 继承 Event：INotification</typeparam>
        /// <param name="event">事件模型，比如StudentRegisteredEvent</param>
        /// <returns></returns>
        public Task RaiseEvent<T>(T @event) where T : Event
        {
            if (!@event.MessageType.Equals("DomainNotification"))
                _eventStore?.Save(@event);

            return _mediator.Publish(@event);
        }
    }
}
