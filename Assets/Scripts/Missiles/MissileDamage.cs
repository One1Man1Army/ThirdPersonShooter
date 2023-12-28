using TPS.CommonLogic;
using UnityEngine;
using Zenject;

namespace TPS.Missiles
{
    public sealed class MissileDamage : MonoBehaviour
    {
        #region Fields
        [SerializeField] private Missile _missile;

        private float _damage;
        private float _damageRadius;

        private readonly Collider[] _hits = new Collider[10];
        #endregion

        [Inject]
        public void Construct(GameSettings gameSettings)
        {
            _missile.OnExplode += MakeDamage;

            _damage = gameSettings.missileDamage;
            _damageRadius = gameSettings.missileDamageRadius;
        }

        private void MakeDamage(Missile missile)
        {
            var hitsCount = Physics.OverlapSphereNonAlloc(transform.position, _damageRadius, _hits);
            for (int i = 0; i < hitsCount; i++)
            {
                var hittable = _hits[i].GetComponent<IHittable>();

                if (hittable != null)
                    hittable.TakeHit(_damage, transform);
            }
        }

        private void OnDestroy()
        {
            _missile.OnExplode -= MakeDamage;
        }
    }
}
