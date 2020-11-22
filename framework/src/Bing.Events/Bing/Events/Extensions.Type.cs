using System;

namespace Bing.Events
{
    /// <summary>
    /// 类型(<see cref="Type"/>) 扩展
    /// </summary>
    internal static class TypeExtensions
    {
        /// <summary>
        /// 是否事件
        /// </summary>
        /// <param name="eventType">事件类型</param>
        public static bool IsEvent(this Type eventType) => typeof(Event).IsAssignableFrom(eventType);

        /// <summary>
        /// 能否处理指定事件
        /// </summary>
        /// <param name="handlerType">处理器类型</param>
        /// <param name="eventType">事件类型</param>
        public static bool CanHandle(this Type handlerType, Type eventType)
        {
            var type = typeof(IEventHandler<>).MakeGenericType(eventType);
            return type.IsAssignableFrom(handlerType);
        }
    }
}
