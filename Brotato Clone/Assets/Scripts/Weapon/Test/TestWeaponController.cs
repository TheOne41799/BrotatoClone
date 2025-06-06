using BrotatoClone.Common;
using BrotatoClone.Data;
using BrotatoClone.Event;
using System.Collections.Generic;
using UnityEngine;

namespace BrotatoClone.Weapon
{
    public class TestWeaponController
    {
        private WeaponManager weaponManager;
        private TestWeaponModel model;
        private TestWeaponView view;
        private TestWeaponPool testWeaponPool;

        public TestWeaponController(TestWeaponData testWeaponData, WeaponManager weaponManager, TestWeaponPool testWeaponPool)
        {
            this.weaponManager = weaponManager;
            this.testWeaponPool = testWeaponPool;

            model = new TestWeaponModel(testWeaponData);
            model.SetController(this);

            view = GameObject.Instantiate<TestWeaponView>(testWeaponData.TestWeaponViewPrefab);
            view.SetController(this);

            model.SetViewTransform(view.GetTransform());
            view.SetEnemyDetectionVariables(model.HitDetectionRadius, model.LayerMask, model.EnemyDetectionRange);
        }

        public Transform OnWeaponTransformRequested()
        {
            return view.GetTestWeaponTransform();
        }

        public void OnGetFromPool()
        {
            view.gameObject.SetActive(true);
        }

        public void OnReturnToPool()
        {
            view.gameObject.SetActive(false);
        }

        public void OnDestroyFromPool()
        {
            GameObject.Destroy(view.gameObject);
        }

        public void ReleaseToPool()
        {
            testWeaponPool.Release(this);
        }

        public void OnUpdate()
        {
            model.OnUpdate();
            view.DetectEnemies();
        }

        public void Rotate(Quaternion quaternion, float rotationSpeed)
        {
            view.Rotate(quaternion, rotationSpeed);
        }

        public void DetectedEnemies(List<IDamageable> enemies)
        {
            model.SetDetectedEnemies(enemies);

            if (enemies.Count > 0)
            {
                foreach (var enemy in enemies)
                {
                    model.Attack(enemy);
                }
            }
            else
            {
                model.StopAttack();
            }
        }

        public void PlayAttackAnimation()
        {
            view.PlayAttackAnimation();
        }

        public void StopAttack()
        {
            model.StopAttack();
        }

        public void HandleEnemyHit(DamageDisplayData damageDisplayData)
        {
            weaponManager.HandleEnemyHit(damageDisplayData);
        }
    }
}