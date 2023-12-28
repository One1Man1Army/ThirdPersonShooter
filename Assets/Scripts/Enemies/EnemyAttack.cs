using TPS.CommonLogic;
using UnityEngine;

namespace TPS.Enemies
{
    public sealed class EnemyAttack : MonoBehaviour
	{
		[SerializeField] TriggerObserver _triggerObserver;

        [SerializeField] private float _damage = 10f;

        private void Awake()
        {
            _triggerObserver.TriggerEnter += AttackPlayer;
        }

        private void AttackPlayer(Collider collider)
        {
            if (collider.CompareTag("Player"))
                collider.GetComponent<IHealth>().TakeHit(_damage, transform);
        }

        private void OnDestroy()
        {
            _triggerObserver.TriggerEnter -= AttackPlayer;
        }
    }
}
