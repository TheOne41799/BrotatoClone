using BrotatoClone.Common;
using BrotatoClone.Data;
using UnityEngine;

namespace BrotatoClone.Enemy
{
    public class EnemyView : MonoBehaviour, IEnemyView
    {
        private IViewObserver enemyController;
        private Vector2 velocity;

        private EnemyData enemyData;

        [Header("Renderers")]
        [SerializeField] private SpriteRenderer enemySprite;
        [SerializeField] private SpriteRenderer spawnIndicator;

        [Header("Death Effects")]
        [SerializeField] private ParticleSystem deathEffect;

        [Header("DEBUG")]
        [SerializeField] private bool isGizmosON;

        private void Awake()
        {
            enemySprite.enabled = false;
            spawnIndicator.enabled = true;
        }

        public void SetController(IViewObserver enemyController)
        {
            this.enemyController = enemyController;
        }

        public void SetEnemyData(EnemyData enemyData)
        {
            this.enemyData = enemyData;
        }

        public void RunSpawnIndicatorTween()
        {
            Vector3 targetScale = spawnIndicator.transform.localScale * 1.2f;
            LeanTween.scale(spawnIndicator.gameObject, targetScale, 0.3f)
                .setLoopPingPong(4)
                .setOnComplete(SpawnSequenceCompleted);

            /*TweenScalePingPongData scaleData = new TweenScalePingPongData(new Vector3(1.5f, 1.5f, 1f), 0.5f, 4);
            TweenEventData eventData = new TweenEventData(TweenType.SCALE_PING_PONG, spawnIndicator.gameObject, scaleData);*/
        }

        public void SpawnSequenceCompleted()
        {
            enemySprite.enabled = true;
            spawnIndicator.enabled = false;

            enemyController.OnSpawnSequenceCompleted();
        }

        public Vector2 GetPosition()
        {
            return this.transform.position;
        }

        public void Move(Vector2 velocity)
        {
            this.velocity = velocity;
        }        

        private void Update()
        {
            transform.position += (Vector3)(velocity * Time.deltaTime);
        }

        private void OnDrawGizmos()
        {
            if(!isGizmosON) return;

            Gizmos.color = Color.black;
            Gizmos.DrawWireSphere(this.transform.position, enemyData.AttackRange);
        }

        public void PlayDeathEffect()
        {
            deathEffect.transform.SetParent(null);
            deathEffect.Play();
        }
    }
}