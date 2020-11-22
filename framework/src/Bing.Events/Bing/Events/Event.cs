using System;
using System.Text;
using Bing.Utils.Json;

namespace Bing.Events
{
    /// <summary>
    /// 事件
    /// </summary>
    public class Event : IEvent
    {
        /// <summary>
        /// 事件标识
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 事件时间
        /// </summary>
        public DateTime Time { get; }

        /// <summary>
        /// 初始化一个<see cref="Event"/>类型的实例
        /// </summary>
        public Event()
        {
            Id = Helpers.Id.Guid();
            Time = DateTime.Now;
        }

        /// <summary>
        /// 输出日志
        /// </summary>
        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendLine($"事件类型: {GetType().Name}");
            result.AppendLine($"事件标识: {Id}");
            result.AppendLine($"事件时间: {Time:yyyy-MM-dd HH:mm:ss.fff}");
            result.AppendLine($"事件数据: {(this).ToJson()}");
            return result.ToString();
        }
    }
}
