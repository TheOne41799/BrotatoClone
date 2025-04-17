using UnityEngine;

namespace BrotatoClone.Input
{
    public interface IControllerOberver
    {
        void OnPlayerMove(Vector2 moveInput);
    }
}