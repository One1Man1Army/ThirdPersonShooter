using DG.Tweening;
using TPS.VFX;
using UnityEngine;

namespace TPS.InternalLogic
{
    public sealed class VFXFactory : IVFXFactory
    {
        private readonly MissileExplodeVFX.Pool _missileExplodePool;
        private readonly EnemyDeathVFX.Pool _enemyDeathPool;

        public VFXFactory(MissileExplodeVFX.Pool missileExplodePool, EnemyDeathVFX.Pool enemyDeathPool)
        {
            _missileExplodePool = missileExplodePool;
            _enemyDeathPool = enemyDeathPool;
        }

        public void Create(VFXType type, Vector3 pos)
        {
            switch (type)
            {
                case VFXType.MissileExplode:
                    var explode = _missileExplodePool.Spawn();
                    explode.transform.position = pos;
                    DOVirtual.DelayedCall(explode.Duration, () => _missileExplodePool.Despawn(explode));
                    break;
                case VFXType.EnemyDeath:
                    var death = _enemyDeathPool.Spawn();
                    death.transform.position = pos;
                    DOVirtual.DelayedCall(death.Duration, () => _enemyDeathPool.Despawn(death));
                    break;
            }
        }
    }
}
