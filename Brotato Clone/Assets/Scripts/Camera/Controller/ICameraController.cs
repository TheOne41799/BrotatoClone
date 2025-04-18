using BrotatoClone.Common;
using UnityEngine;

namespace BrotatoClone.Camera
{
    public interface ICameraController
    {
        void SetCameraTarget(ITarget target);
    }
}