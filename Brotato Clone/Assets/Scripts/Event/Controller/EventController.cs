using System;
using System.Collections.Generic;

namespace BrotatoClone.Event
{
    public class EventController<TDelegate> : IEventController<TDelegate> where TDelegate : Delegate
    {
        private TDelegate eventListeners;

        public void AddListener(TDelegate listener)
        {
            eventListeners = (TDelegate)Delegate.Combine(eventListeners, listener);
        }

        public void RemoveListener(TDelegate listener)
        {
            eventListeners = (TDelegate)Delegate.Remove(eventListeners, listener);
        }

        private void InvokeListeners(object[] args)
        {
            if (eventListeners == null) return;

            foreach (Delegate listener in eventListeners.GetInvocationList())
            {
                listener?.DynamicInvoke(args);
            }
        }

        public void Invoke(params object[] args)
        {
            InvokeListeners(args);
        }

        public void Broadcast(params object[] args)
        {
            InvokeListeners(args);
        }

        public TResult Invoke<TResult>(params object[] args)
        {
            if (eventListeners == null) return default;

            foreach (Delegate listener in eventListeners.GetInvocationList())
            {
                if (listener is Func<TResult> funcNoArgs)
                {
                    return funcNoArgs();
                }
                else if (listener is Func<object[], TResult> funcWithArgs)
                {
                    return funcWithArgs(args);
                }
            }

            return default;
        }

        public List<TResult> Broadcast<TResult>(params object[] args)
        {
            List<TResult> results = new List<TResult>();

            if (eventListeners == null) return results;

            foreach (Delegate listener in eventListeners.GetInvocationList())
            {
                if (listener is Func<TResult> funcNoArgs)
                {
                    results.Add(funcNoArgs());
                }
                else if (listener is Func<object[], TResult> funcWithArgs)
                {
                    results.Add(funcWithArgs(args));
                }
            }

            return results;
        }
    }
}