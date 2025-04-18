using BrotatoClone.Camera;
using BrotatoClone.Input;
using BrotatoClone.Player;
using UnityEngine;

namespace BrotatoClone.Data
{
    [CreateAssetMenu(menuName = "Game Data/ Game Data", fileName = "Game Data")]
    public class GameData : ScriptableObject
    {
        [SerializeField] private InputManager inputManagerPrefab;
        [SerializeField] private CameraManager cameraManagerPrefab;
        [SerializeField] private PlayerManager playerManagerPrefab;

        public InputManager InputManagerPrefab => inputManagerPrefab;
        public CameraManager CameraManagerPrefab => cameraManagerPrefab;
        public PlayerManager PlayerManagerPrefab => playerManagerPrefab;
    }
}