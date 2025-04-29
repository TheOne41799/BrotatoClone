using UnityEngine;
using TMPro;
using BrotatoClone.Common;

namespace BrotatoClone.VFX
{
    public class DamageText : MonoBehaviour
    {
        [SerializeField] private Animator damageTextAnimator;
        [SerializeField] private TextMeshPro damageText;

        public void PlayDamageTextAnimation(float damageAmount)
        {
            damageText.text = damageAmount.ToString();

            damageTextAnimator.Play("DamageTextAnimate");
        }
    }
}