using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Bing.Serialization;

namespace Bing.Events
{
    /// <summary>
    /// 管道事件总线
    /// </summary>
    public class ChannelEventBus : IEventBus
    {
        /// <summary>
        /// 订阅信息存储器
        /// </summary>
        private readonly ISubscriptionInfoStore _subscriptionInfoStore;

        /// <summary>
        /// 事件处理器工厂
        /// </summary>
        private readonly IEventHandlerFactory _eventHandlerFactory;

        /// <summary>
        /// 序列化器
        /// </summary>
        private readonly IJsonSerializer _serializer;

        /// <summary>
        /// 发布事件
        /// </summary>
        /// <typeparam name="TEvent">事件类型</typeparam>
        /// <param name="event">事件</param>
        public async Task PublishAsync<TEvent>(TEvent @event) where TEvent : IEvent
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 订阅事件
        /// </summary>
        /// <typeparam name="TEvent">事件类型</typeparam>
        /// <typeparam name="TEventHandler">事件处理器</typeparam>
        /// <returns></returns>
        public async Task SubscribeAsync<TEvent, TEventHandler>() where TEvent : IEvent where TEventHandler : IEventHandler<TEvent>
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 订阅事件
        /// </summary>
        /// <param name="eventType">事件类型</param>
        /// <param name="handlerType">事件处理器类型</param>
        public async Task SubscribeAsync(Type eventType, Type handlerType)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 订阅事件
        /// </summary>
        /// <typeparam name="TEvent">事件类型</typeparam>
        /// <typeparam name="TEventHandler">事件处理器类型</typeparam>
        public void Unsubscribe<TEvent, TEventHandler>() where TEvent : IEvent where TEventHandler : IEventHandler<IEvent>
        {
            throw new NotImplementedException();
        }
    }
}
