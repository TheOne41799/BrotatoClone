using UnityEngine;

namespace BrotatoClone.Input
{
    public interface IInputControllerOberver
    {
        void HandleMoveInput(Vector2 moveInput);
    }
}