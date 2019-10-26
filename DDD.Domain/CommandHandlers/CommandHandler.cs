using DDD.Domain.Core.Bus;
using DDD.Domain.Core.Commands;
using DDD.Domain.Core.Notifications;
using DDD.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.Domain.CommandHandlers
{
    /// <summary>
    /// 领域命令处理程序
    /// 用来作为全部处理程序的基类，提供公共方法和接口数据
    /// </summary>
    public class CommandHandler
    {
        // 注入工作单元
        private readonly IUnitOfWork _uow;
        // 注入中介处理接口（目前用不到，在领域事件中用来发布事件）
        private readonly IMediatorHandler _bus;
        // 注入缓存，用来存储错误信息（目前是错误方法，以后用领域通知替换）
        private IMemoryCache _cache;

        private readonly DomainNotificationHandler _notifications;
        /// <summary>
        /// 构造函数注入
        /// </summary>
        /// <param name="uow"></param>
        /// <param name="bus"></param>
        /// <param name="cache"></param>
        public CommandHandler(IUnitOfWork uow, IMediatorHandler bus, INotificationHandler<DomainNotification> notifications)
        {
            _uow = uow;
            _notifications = (DomainNotificationHandler)notifications;
            _bus = bus;
        }

        protected void NotifyValidationErrors(Command message)
        {
            foreach (var error in message.ValidationResult.Errors)
            {
                _bus.RaiseEvent(new DomainNotification(message.MessageType, error.ErrorMessage));
            }
        }


        //工作单元提交
        //如果有错误，下一步会在这里添加领域通知
        public bool Commit()
        {
            if (_notifications.HasNotifications()) return false;
            if (_uow.Commit()) return true;

            _bus.RaiseEvent(new DomainNotification("Commit", "We had a problem during saving your data."));
            return false;
        }
    }
}
