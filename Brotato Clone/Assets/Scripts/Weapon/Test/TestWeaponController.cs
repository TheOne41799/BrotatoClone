using BrotatoClone.Common;
using BrotatoClone.Data;
using UnityEngine;

namespace BrotatoClone.Weapon
{
    public class TestWeaponController
    {
        private TestWeaponModel model;
        private TestWeaponView view;

        public TestWeaponController(TestWeaponData testWeaponData)
        {
            model = new TestWeaponModel(testWeaponData);
            model.SetController(this);

            view = GameObject.Instantiate<TestWeaponView>(testWeaponData.TestWeaponViewPrefab);
            view.SetController(this);

            model.SetViewTransform(view.GetTransform());
            view.SetEnemyDetectionVariables(model.HitDetectionRadius, model.LayerMask);
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

        public void DetectedEnemy(IDamageable enemy)
        {
            model.Attack(enemy);
        }
    }
}