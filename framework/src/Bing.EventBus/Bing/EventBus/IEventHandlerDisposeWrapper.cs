using System;

namespace Bing.EventBus
{
    public interface IEventHandlerDisposeWrapper:IDisposable
    {
        IEventHandler EventHandler { get; }
    }
}
