using System;
using UnityEngine;

namespace TPS.CommonLogic
{
    public class Health : MonoBehaviour, IHealth
    {
        #region Fields
        [SerializeField] private float _maxHP = 1f;

        public event Action HealthChanged;
        public Transform DamageSource;

        public float Current { get; set; }

        public float Max => _maxHP;

        #endregion

        private void Awake()
        {
            Current = Max;
        }

        public void TakeHit(float damage, Transform damageSource)
        {
            if (Current <= 0)
                return;

            DamageSource = damageSource;
            Current -= damage;
            HealthChanged?.Invoke();
        }
    }
}
