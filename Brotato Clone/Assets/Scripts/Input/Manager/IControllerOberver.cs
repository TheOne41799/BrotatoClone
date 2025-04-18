using UnityEngine;

namespace BrotatoClone.Input
{
    public interface IControllerOberver
    {
        void HandleMoveInput(Vector2 moveInput);
    }
}