using TPS.CommonLogic;
using UnityEngine;
using Zenject;

namespace TPS.Player
{
    public sealed class RagdollSwitcher : MonoBehaviour
    {
        [SerializeField] private Collider[] _colliders;
        [SerializeField] private Rigidbody[] _rigidbodies;

        private float _forceOnDeath;
        private float _forceRadius;

        [Inject]
        public void Construct(GameSettings settings)
        {
            _forceOnDeath = settings.playerForceOnDeath;
            _forceRadius = settings.playerForceOnDeathRadius;
        }

        public void SwitchRagdoll(bool on)
        {
            foreach (Collider collider in _colliders)
            {
                collider.enabled = on;
                collider.isTrigger = !on;
            }

            foreach (Rigidbody body in _rigidbodies)
            {
                body.isKinematic = !on;
            }
        }

        public void ApplyForceOnDeath(Transform deathDealer)
        {
            foreach(Rigidbody rigidbody in _rigidbodies)
            {
                rigidbody.AddExplosionForce(_forceOnDeath, deathDealer.position, _forceRadius);
            }
        }
    }
}
