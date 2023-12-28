using UnityEngine;
using Zenject;

namespace TPS.VFX
{
    public class PoolableVFX : MonoBehaviour, IPoolable
    {
        public float Duration { get; private set; }

        [SerializeField] private ParticleSystem _particleSystem;

        private void Awake()
        {
            Duration = _particleSystem.main.duration;
        }

        public void OnDespawned()
        {

        }

        public void OnSpawned()
        { 
        }
    }
}
