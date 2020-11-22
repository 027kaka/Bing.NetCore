using System;

namespace Bing.Events
{
    /// <summary>
    /// 事件总线异常
    /// </summary>
    [Serializable]
    public class EventBusException : BingException
    {
        /// <summary>
        /// 事件总线标识
        /// </summary>
        protected const string EventBusFlag = "__BING_EVENT_BUS";
    }
}
