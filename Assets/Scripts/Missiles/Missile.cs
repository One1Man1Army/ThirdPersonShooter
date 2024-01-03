using DG.Tweening;
using System;
using TPS.CommonLogic;
using TPS.InternalLogic;
using UnityEngine;
using Zenject;

namespace TPS.Missiles
{
    [RequireComponent(typeof(Collider))]
    public sealed class Missile : MonoBehaviour, IPoolable<Vector3, Quaternion, IMemoryPool>, IDisposable
    {
        #region Fields
        public event Action<Missile> OnExplode;

        private IVFXFactory _vfxFactory;
        private IMemoryPool _pool;

        private float _selfDestroyTime;

        private bool _hasExploded;
        #endregion

        [Inject]
        public void Construct(IVFXFactory vfxFactory, GameSettings settings)
        {
            _vfxFactory = vfxFactory;

            _selfDestroyTime = settings.missileSelfDestroyTime;
        }

        public void OnSpawned(Vector3 pos, Quaternion rot, IMemoryPool pool)
        {
            transform.position = pos;
            transform.rotation = rot;

            _pool = pool;

            _hasExploded = false;
            SetSelfDestroyTimer();
        }

        private void OnTriggerEnter(Collider other)
        {
            CheckHit(other);
        }

        private void CheckHit(Collider other)
        {
            if (other.CompareTag(Constants.PlayerTag))
                return;

            if (other.GetComponent<IHittable>() != null)
            {
                Explode();
            }
        }

        public void Explode()
        {
            if (_hasExploded)
                return;

            _hasExploded = true;
            SpawnExplodeVFX();
            OnExplode?.Invoke(this);
        }

        private void SpawnExplodeVFX()
        {
            _vfxFactory.Create(VFXType.MissileExplode, transform.position);
        }

        private void SetSelfDestroyTimer()
        {
            DOVirtual.DelayedCall(_selfDestroyTime, Explode);
        }

        public void Dispose()
        {
            _pool.Despawn(this);
        }

        public void OnDespawned()
        {
            _pool = null;
        }

        public class Factory : PlaceholderFactory<Vector3, Quaternion, Missile>
        {
        }
    }
}
