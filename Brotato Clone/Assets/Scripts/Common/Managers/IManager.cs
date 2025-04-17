using BrotatoClone.Event;

namespace BrotatoClone.Common
{
    public interface IManager
    {
        void InitializeManager(IEventManager eventManager);
    }
}