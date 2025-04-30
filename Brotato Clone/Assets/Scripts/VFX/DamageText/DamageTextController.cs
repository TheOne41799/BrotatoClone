using BrotatoClone.Common;
using BrotatoClone.Data;
using UnityEngine;
using UnityEngine.Pool;
using System.Collections;

namespace BrotatoClone.VFX
{
    public class DamageTextController
    {
        private VFXManager vfxManager;
        private VFXData vfxData;

        private ObjectPool<DamageText> damageTextPool;

        public DamageTextController(VFXData vfxData, VFXManager vfxManager)
        {
            this.vfxData = vfxData;
            this.vfxManager = vfxManager;

            damageTextPool = new ObjectPool<DamageText>(CreateDamageText, OnGetDamageText, OnReleaseDamageText, OnDestroyDamageText);
        }

        private DamageText CreateDamageText()
        {
            return GameObject.Instantiate(vfxData.DamageTextPrefab, vfxManager.transform);
        }

        private void OnGetDamageText(DamageText damageText)
        {
            damageText.gameObject.SetActive(true);
        }

        private void OnReleaseDamageText(DamageText damageText)
        {
            damageText.gameObject.SetActive(false); 
        }
 
        private void OnDestroyDamageText(DamageText damageText)
        {
            GameObject.Destroy(damageText.gameObject);
        }

        public void HandleEnemyHit(DamageDisplayData damageDisplayData)
        {
            Vector2 spawnPosition = damageDisplayData.spawnPosition;

            DamageText damageTextPooledObject = damageTextPool.Get();
            damageTextPooledObject.transform.position = spawnPosition;

            damageTextPooledObject.PlayDamageTextAnimation(damageDisplayData.damageAmount);

            //LeanTween.delayedCall(1f, () => damageTextPool.Release(damageTextPooledObject));
            vfxManager.StartCoroutine(ReleaseAfterDelay(damageTextPooledObject, 1f));
        }

        private IEnumerator ReleaseAfterDelay(DamageText damageText, float delay)
        {
            yield return new WaitForSeconds(delay);
            damageTextPool.Release(damageText);
        }
    }
}