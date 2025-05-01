using BrotatoClone.Common;
using UnityEngine;

namespace BrotatoClone.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerView : MonoBehaviour, IPlayerView, ITarget
    {
        [SerializeField] private Rigidbody2D playerRB;
        [SerializeField] private Transform weaponTransform;
        private Vector2 velocity;

        public Transform TargetTransform { get; private set; }

        private void Awake()
        {
            TargetTransform = this.transform;
        }

        public void UpdateVelocity(Vector2 velocity)
        {
            this.velocity = velocity;
        }

        private void FixedUpdate()
        {
            playerRB.linearVelocity = velocity;
        }

        public void AddWeapon(WeaponSpawnData weaponSpawnData)
        {
            weaponSpawnData.weaponTransform.SetParent(weaponTransform);
            weaponSpawnData.weaponTransform.localPosition = Vector3.zero;
            weaponSpawnData.weaponTransform.localRotation = Quaternion.identity;
        }

        private void OnTriggerEnter2D(Collider2D collider)
        {
            if(collider.TryGetComponent(out ICollectible currencyOneItem))
            {
                currencyOneItem.OnCashCollected(this.transform);
            }
        }
    }
}