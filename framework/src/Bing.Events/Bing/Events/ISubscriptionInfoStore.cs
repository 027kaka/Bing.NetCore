using System;
using System.Collections.Generic;

namespace Bing.Events
{
    /// <summary>
    /// 订阅信息存储器
    /// </summary>
    public interface ISubscriptionInfoStore
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <typeparam name="TEvent">事件类型</typeparam>
        /// <typeparam name="TEventHandler">事件处理器类型</typeparam>
        void Add<TEvent, TEventHandler>()
            where TEvent : IEvent
            where TEventHandler : IEventHandler<TEvent>;

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="eventType">事件类型</param>
        /// <param name="eventHandlerType">事件处理器类型</param>
        void Add(Type eventType, Type eventHandlerType);

        /// <summary>
        /// 获取事件处理器列表
        /// </summary>
        /// <param name="eventType">事件类型</param>
        IReadOnlyCollection<SubscriptionInfo> GetHandlers(string eventType);

        /// <summary>
        /// 获取事件键
        /// </summary>
        /// <typeparam name="T">事件类型</typeparam>
        string GetEventKey<T>();

        /// <summary>
        /// 获取事件键
        /// </summary>
        /// <param name="type">事件类型</param>
        string GetEventKey(Type type);

        /// <summary>
        /// 移除
        /// </summary>
        /// <typeparam name="TEvent">事件类型</typeparam>
        /// <typeparam name="TEventHandler">事件处理器类型</typeparam>
        void Remove<TEvent,TEventHandler>()
            where TEvent : IEvent
            where TEventHandler : IEventHandler<TEvent>;
    }
}
