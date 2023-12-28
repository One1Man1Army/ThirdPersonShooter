using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace TPS.Missiles
{
    public sealed class MissilesLauncher : MonoBehaviour
    {
        [SerializeField] private Transform _missilesSpawnPoint;

        private Missile.Factory _missilesFactory;

        private readonly List<Missile> _missiles = new List<Missile>();

        [Inject]
        public void Construct(Missile.Factory factory)
        {
            _missilesFactory = factory;
        }

        public void SpawnMissile()
        {
            var missile = _missilesFactory.Create(_missilesSpawnPoint.position, _missilesSpawnPoint.rotation);
            missile.OnExplode += RemoveMissile;
            _missiles.Add(missile);
        }

        public void RemoveMissile(Missile missile)
        {
            missile.OnExplode -= RemoveMissile;
            missile.Dispose();
            _missiles.Remove(missile);
        }
    }
}
