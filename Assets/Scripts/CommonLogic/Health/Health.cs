using System;
using TPS.Enemies;
using UnityEngine;
using Zenject;

namespace TPS.CommonLogic
{
    public abstract class Health : MonoBehaviour, IHittable
    {
        public event Action HealthChanged;
        public Transform DamageSource;
        public float Current { get; private set; }
        public float Max { get; private set; }

        public void TakeHit(float damage, Transform damageSource)
        {
            if (Current <= 0)
                return;

            DamageSource = damageSource;
            Current -= damage;
            HealthChanged?.Invoke();
        }

        internal abstract void InitializeHP(GameSettings gameSettings);

        protected internal void SetValues(float max)
        {
            Max = max;
            Current = max;
        }
    }
}
