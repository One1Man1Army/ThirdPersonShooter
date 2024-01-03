using TPS.CommonLogic;
using TPS.InternalLogic;
using UnityEngine;
using Zenject;

namespace TPS.Enemies
{
    [RequireComponent(typeof(Collider))]
    public sealed class EnemyAttack : MonoBehaviour
	{
        [SerializeField] private Enemy _self;

        private float _damage;

        [Inject]
        public void Construct(GameSettings gameSettings)
        {
            SetDamage(gameSettings);
        }

        private void OnTriggerEnter(Collider other)
        {
            AttackPlayer(other);
        }

        private void AttackPlayer(Collider collider)
        {
            if (collider.CompareTag("Player"))
                collider.GetComponent<Health>().TakeHit(_damage, transform);
        }

        private void SetDamage(GameSettings gameSettings)
        {
            switch (_self.Type)
            {
                case EnemyType.Simple:
                    _damage = gameSettings.simpleEnemyDamage;
                    break;
                case EnemyType.Boss:
                    _damage = gameSettings.bossEnemyDamage;
                    break;
            }
        }
    }
}
