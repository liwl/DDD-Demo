﻿using DDD.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.Domain.Core.Notifications
{
    /// <summary>
    /// 领域通知模型，用来获取当前总线中出现的通知信息
    /// 继承自领域事件和 INotification（也就意味着可以拥有中介的发布/订阅模式）
    /// </summary>
    public class DomainNotification : Event
    {
        public Guid DomainNotificationId { get; private set; }
        // 键（可以根据这个key，获取当前key下的全部通知信息）
        public string Key { get; private set; }
        // 值（与key对应）
        public string Value { get; private set; }
        public int Version { get; private set; }

        public DomainNotification(string key, string value)
        {
            DomainNotificationId = Guid.NewGuid();
            Version = 1;
            Key = key;
            Value = value;
        }
    }
}
