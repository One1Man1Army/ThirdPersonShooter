using TPS.CommonLogic;
using TPS.InternalLogic;
using UnityEngine;
using Zenject;

namespace TPS.Enemies
{
	public sealed class EnemyDeath : MonoBehaviour
	{
        [SerializeField] private Health _enemyHealth;
		[SerializeField] private EnemyMove _follow;
        [SerializeField] private GameObject _onDeathEffect;

		private IVFXFactory _vfxfactory;

		[Inject]
		public void Construct(IVFXFactory vfxFactory)
		{
			_vfxfactory = vfxFactory;
            _enemyHealth.HealthChanged += OnHealthChanged;
        }

		private void OnHealthChanged()
		{
			if (_enemyHealth.Current <= 0)
				Die();
		}

		private void Die()
		{
			_enemyHealth.HealthChanged -= OnHealthChanged;
			_follow.enabled = false;
            SpawnDeathVFX();
			Destroy(gameObject);
        }

        private void SpawnDeathVFX()
        {
			_vfxfactory.Create(VFXType.EnemyDeath, transform.position);
        }

        private void OnDestroy()
        {
            _enemyHealth.HealthChanged -= OnHealthChanged;
        }
    }
}