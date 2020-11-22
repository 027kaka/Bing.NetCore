using System;

namespace Bing.EventBus
{
    /// <summary>
    /// 事件处理器自动释放包装
    /// </summary>
    public interface IEventHandlerDisposeWrapper : IDisposable
    {
        /// <summary>
        /// 事件处理器
        /// </summary>
        IEventHandler EventHandler { get; }
    }
}
