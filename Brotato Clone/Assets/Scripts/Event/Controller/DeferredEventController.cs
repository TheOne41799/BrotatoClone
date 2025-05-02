using System;
using System.Collections.Generic;

namespace BrotatoClone.Event
{
    public class DeferredEventController<TDelegate> : IEventController<TDelegate> where TDelegate : Delegate
    {
        private EventController<TDelegate> innerController;
        private Queue<object[]> queuedInvokes;
        private bool hasListeners;

        public DeferredEventController()
        {
            innerController = new EventController<TDelegate>();
            queuedInvokes = new Queue<object[]>();
            hasListeners = false;
        }

        public void AddListener(TDelegate listener)
        {
            innerController.AddListener(listener);
            hasListeners = true;

            while (queuedInvokes.Count > 0)
            {
                object[] args = queuedInvokes.Dequeue();
                innerController.Invoke(args);
            }
        }

        public void RemoveListener(TDelegate listener)
        {
            innerController.RemoveListener(listener);
        }

        public void Invoke(params object[] args)
        {
            if (hasListeners)
            {
                innerController.Invoke(args);
            }
            else
            {
                queuedInvokes.Enqueue(args);
            }
        }

        public void Broadcast(params object[] args)
        {
            if (hasListeners)
            {
                innerController.Broadcast(args);
            }
            else
            {
                queuedInvokes.Enqueue(args);
            }
        }

        public TResult Invoke<TResult>(params object[] args)
        {
            if (hasListeners)
            {
                return innerController.Invoke<TResult>(args);
            }

            queuedInvokes.Enqueue(args);
            return default(TResult);
        }

        public List<TResult> Broadcast<TResult>(params object[] args)
        {
            if (hasListeners)
            {
                return innerController.Broadcast<TResult>(args);
            }

            queuedInvokes.Enqueue(args);
            return new List<TResult>();
        }
    }
}
    
