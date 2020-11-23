using System;

namespace Bing.EventBus.Local
{
    /// <summary>
    /// 本地事件总线
    /// </summary>
    public interface ILocalEventBus : IEventBus
    {
        /// <summary>
        /// 订阅事件
        /// </summary>
        /// <typeparam name="TEvent">事件类型</typeparam>
        /// <param name="eventHandler">本地事件处理器</param>
        IDisposable Subscribe<TEvent>(ILocalEventHandler<TEvent> eventHandler)
            where TEvent : class;
    }
}
