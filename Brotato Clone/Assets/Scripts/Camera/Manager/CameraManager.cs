using BrotatoClone.Common;
using BrotatoClone.Event;
using Unity.Cinemachine;
using UnityEngine;

namespace BrotatoClone.Camera
{
    public class CameraManager : MonoBehaviour, IManager
    {
        [SerializeField] private CinemachineCamera cinemachineCamera;

        private IEventManager eventManager;

        private ICameraController cameraController;

        private void Awake()
        {
            CreateCameraController();
        }

        private void CreateCameraController()
        {
            cameraController = new CameraController(cinemachineCamera);
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
            eventManager.PlayerEvents.OnCameraTargetCreated.AddListener(ReceiveCameraTarget);

            // create an event to indicate player has been destroyed or use the same event
        }

        private void ReceiveCameraTarget(ITarget target)
        {
            cameraController.SetCameraTarget(target);
        }
    }
}