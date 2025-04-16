using System.Collections.Generic;
using System;

namespace BrotatoClone.Event
{
    public interface IEventController<TDelegate> where TDelegate : Delegate
    {
        void AddListener(TDelegate listener);
        void RemoveListener(TDelegate listener);

        void Invoke(params object[] args);
        void Broadcast(params object[] args);

        TResult Invoke<TResult>(params object[] args);
        List<TResult> Broadcast<TResult>(params object[] args);
    }
}