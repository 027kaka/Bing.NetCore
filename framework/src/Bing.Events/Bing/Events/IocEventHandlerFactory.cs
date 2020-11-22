using System;
using Microsoft.Extensions.DependencyInjection;

namespace Bing.Events
{
    /// <summary>
    /// 依赖注入事件处理器工厂
    /// </summary>
    public class IocEventHandlerFactory : IEventHandlerFactory
    {
        /// <summary>
        /// 服务提供程序
        /// </summary>
        private readonly IServiceProvider _serviceProvider;

        /// <summary>
        /// 初始化一个<see cref="IocEventHandlerFactory"/>类型的实例
        /// </summary>
        /// <param name="serviceProvider">服务提供程序</param>
        public IocEventHandlerFactory(IServiceProvider serviceProvider) => _serviceProvider = serviceProvider;

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="handlerType">事件处理器类型</param>
        public object Create(Type handlerType)
        {
            var scope = _serviceProvider.CreateScope();
            return scope.ServiceProvider.GetService(handlerType);
        }
    }
}
