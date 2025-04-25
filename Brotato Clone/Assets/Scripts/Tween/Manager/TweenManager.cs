using BrotatoClone.Camera;
using BrotatoClone.Common;
using BrotatoClone.Event;
using Unity.Cinemachine;
using UnityEngine;

namespace BrotatoClone.Tween
{
    public class TweenManager : MonoBehaviour, IManager
    {
        private IEventManager eventManager;

        private ITweenController tweenController;

        private void Awake()
        {
            CreateCameraController();
        }

        private void CreateCameraController()
        {
            tweenController = new TweenController();
        }

        public void InitializeManager(IEventManager eventManager)
        {
            SetManagerDependencies(eventManager);
            RegisterEventListeners();
        }

        private void SetManagerDependencies(IEventManager eventManager)
        {
            this.eventManager = eventManager;
        }

        private void RegisterEventListeners()
        {
            
        }
    }
}