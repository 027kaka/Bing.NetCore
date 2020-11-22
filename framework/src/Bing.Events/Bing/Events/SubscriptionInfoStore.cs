using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace Bing.Events
{
    /// <summary>
    /// 订阅信息存储器
    /// </summary>
    public class SubscriptionInfoStore : ISubscriptionInfoStore
    {
        /// <summary>
        /// 事件处理器类型字典
        /// </summary>
        private readonly ConcurrentDictionary<string, HashSet<SubscriptionInfo>> _eventHandlerTypeDict;

        /// <summary>
        /// 空集合
        /// </summary>
        // ReSharper disable once InconsistentNaming
        private static readonly IReadOnlyCollection<SubscriptionInfo> Empty = new List<SubscriptionInfo>();

        /// <summary>
        /// 事件类型集合
        /// </summary>
        private readonly HashSet<Type> _eventTypes;

        /// <summary>
        /// 初始化一个<see cref="SubscriptionInfoStore"/>类型的实例
        /// </summary>
        public SubscriptionInfoStore()
        {
            _eventTypes = new HashSet<Type>();
            _eventHandlerTypeDict = new ConcurrentDictionary<string, HashSet<SubscriptionInfo>>();
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <typeparam name="TEvent">事件类型</typeparam>
        /// <typeparam name="TEventHandler">事件处理器类型</typeparam>
        public void Add<TEvent, TEventHandler>() 
            where TEvent : IEvent 
            where TEventHandler : IEventHandler<TEvent> => 
            Add(typeof(TEvent),typeof(TEventHandler));

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="eventType">事件类型</param>
        /// <param name="eventHandlerType">事件处理器类型</param>
        public void Add(Type eventType, Type eventHandlerType)
        {
            if(!eventType.IsEvent())
                throw new BingFrameworkException($"{eventType} 不是一个集成事件");
            if(!eventHandlerType.CanHandle(eventType))
                throw new BingFrameworkException($"{eventHandlerType} 不能处理 {eventType} 事件");

            var methodInfo = eventHandlerType.GetMethod("HandleAsync");
            if(methodInfo==null)
                throw new BingFrameworkException($"在类型 {eventHandlerType.FullName} 中找不到处理方法 HandleAsync");

            var eventName = GetEventKey(eventType);
            if (!_eventHandlerTypeDict.ContainsKey(eventName))
                _eventHandlerTypeDict.TryAdd(eventName, new HashSet<SubscriptionInfo>());

            _eventHandlerTypeDict[eventName].Add(new SubscriptionInfo(eventType, eventHandlerType, methodInfo));
            _eventTypes.Add(eventType);
        }

        /// <summary>
        /// 获取事件处理器列表
        /// </summary>
        /// <param name="eventType">事件类型</param>
        public IReadOnlyCollection<SubscriptionInfo> GetHandlers(string eventType)
        {
            if (_eventHandlerTypeDict.TryGetValue(eventType, out var handlerTypes))
                return handlerTypes;
            return Empty;
        }

        /// <summary>
        /// 获取事件键
        /// </summary>
        /// <typeparam name="T">事件类型</typeparam>
        public string GetEventKey<T>() => GetEventKey(typeof(T));

        /// <summary>
        /// 获取事件键
        /// </summary>
        /// <param name="type">事件类型</param>
        public string GetEventKey(Type type) => type.Name;

        /// <summary>
        /// 移除
        /// </summary>
        /// <typeparam name="TEvent">事件类型</typeparam>
        /// <typeparam name="TEventHandler">事件处理器类型</typeparam>
        public void Remove<TEvent, TEventHandler>() where TEvent : IEvent where TEventHandler : IEventHandler<TEvent>
        {
            var eventName = GetEventKey<TEvent>();
            var eventHandlerType = typeof(TEventHandler);
            if (_eventHandlerTypeDict.TryGetValue(eventName, out var handlerTypes))
            {
                var handlerType = handlerTypes.SingleOrDefault(x => x.HandlerType == eventHandlerType);
                if (handlerType != null)
                    handlerTypes.Remove(handlerType);
            }
            _eventTypes.Remove(typeof(TEvent));
        }
    }
}
