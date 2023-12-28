using System;
using UnityEngine;

namespace TPS.Player
{
    public sealed class PlayerAnimator : MonoBehaviour
	{
        #region Fields
        private static readonly int MoveHash = Animator.StringToHash("Walking");

		[SerializeField] private Animator _animator;
		[SerializeField] private CharacterController _characterController;
        [SerializeField] private RagdollSwitcher _ragdollSwitcher;
        #endregion

        private void Update()
		{
			_animator.SetFloat(MoveHash, _characterController.velocity.magnitude, 0.1f, Time.deltaTime);
		}

		public void OnDeath(Transform deathDealer)
		{
			_animator.enabled = false;
			_ragdollSwitcher.SwitchRagdoll(true);
			_ragdollSwitcher.ApplyForceOnDeath(deathDealer);
		}
	}
}