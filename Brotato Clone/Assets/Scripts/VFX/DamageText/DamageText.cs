using UnityEngine;
using TMPro;

namespace BrotatoClone.VFX
{
    public class DamageText : MonoBehaviour
    {
        [SerializeField] private Animator damageTextAnimator;
        [SerializeField] private TextMeshPro damageText;

        private void Awake()
        {
            PlayDamageTextAnimation();
        }

        public void PlayDamageTextAnimation()
        {
            damageText.text = Random.Range(10, 1000).ToString();
            damageTextAnimator.Play("DamageTextAnimate");
        }
    }
}