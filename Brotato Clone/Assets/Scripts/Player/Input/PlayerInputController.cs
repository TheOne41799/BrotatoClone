using UnityEngine;

namespace BrotatoClone.Player
{
    public class PlayerInputController: IPlayerInputController
    {
        public Vector2 GetMovementVector()
        {            
            return Vector2.right;
        }
    }
}
