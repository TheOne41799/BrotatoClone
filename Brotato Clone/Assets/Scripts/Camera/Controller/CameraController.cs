using BrotatoClone.Common;
using Unity.Cinemachine;
using UnityEngine;

namespace BrotatoClone.Camera
{
    public class CameraController: ICameraController
    {
        private CinemachineCamera cinemachineCamera;
        private ITarget target;

        public CameraController(CinemachineCamera cinemachineCamera)
        {
            this.cinemachineCamera = cinemachineCamera;
        }

        public void SetCameraTarget(ITarget target)
        {
            this.target = target;

            if (target == null) return;

            cinemachineCamera.Follow = target.TargetTransform;
        }
    }
}