using UnityEngine;
using TMPro;
using BrotatoClone.Common;

namespace BrotatoClone.VFX
{
    public class DamageText : MonoBehaviour
    {
        [SerializeField] private Animator damageTextAnimator;
        [SerializeField] private TextMeshPro damageText;

        /*private DamageTextController controller;

        public void SetController(DamageTextController controller)
        {
            this.controller = controller;
        }*/

        public void PlayDamageTextAnimation(float damageAmount)
        {
            damageText.text = damageAmount.ToString();

            damageTextAnimator.Play("DamageTextAnimate");
        }
    }
}