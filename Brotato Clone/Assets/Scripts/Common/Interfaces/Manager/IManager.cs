using BrotatoClone.Event;

namespace BrotatoClone.Common
{
    public interface IManager
    {
        void SetManagerDependencies(IDependencyContainer managerDependencies);
    }
}