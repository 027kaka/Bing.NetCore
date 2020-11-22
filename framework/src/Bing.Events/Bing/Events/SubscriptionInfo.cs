using System;
using System.Reflection;

namespace Bing.Events
{
    /// <summary>
    /// 订阅信息
    /// </summary>
    public class SubscriptionInfo
    {
        /// <summary>
        /// 事件处理器类型
        /// </summary>
        private readonly Type _handlerType;

        /// <summary>
        /// 事件类型
        /// </summary>
        public Type EventType { get; private set; }

        /// <summary>
        /// 事件处理器类型
        /// </summary>
        public Type HandlerType => _handlerType;

        /// <summary>
        /// 方法
        /// </summary>
        public MethodInfo Method { get; private set; }

        /// <summary>
        /// 初始化一个<see cref="SubscriptionInfo"/>类型的实例
        /// </summary>
        /// <param name="eventType">事件类型</param>
        /// <param name="handlerType">事件处理器类型</param>
        /// <param name="method">方法</param>
        public SubscriptionInfo(Type eventType, Type handlerType, MethodInfo method)
        {
            EventType = eventType;
            _handlerType = handlerType;
            Method = method;
        }

        /// <summary>
        /// 获取哈希码
        /// </summary>
        public override int GetHashCode() => _handlerType.GetHashCode();
    }
}
