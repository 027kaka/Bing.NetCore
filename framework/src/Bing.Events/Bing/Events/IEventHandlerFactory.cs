using System;

namespace Bing.Events
{
    /// <summary>
    /// 事件处理器工厂
    /// </summary>
    public interface IEventHandlerFactory
    {
        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="handlerType">事件处理器类型</param>
        object Create(Type handlerType);
    }
}
