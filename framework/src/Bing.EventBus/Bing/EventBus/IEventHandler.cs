using System.Threading.Tasks;

namespace Bing.EventBus
{
    /// <summary>
    /// 事件处理器
    /// </summary>
    public interface IEventHandler
    {
    }

    /// <summary>
    /// 事件处理器
    /// </summary>
    /// <typeparam name="TEvent">事件类型</typeparam>
    public interface IEventHandler<in TEvent> where TEvent : class
    {
        /// <summary>
        /// 处理
        /// </summary>
        /// <param name="eventData">事件数据</param>
        Task HandleAsync(TEvent eventData);
    }
}
