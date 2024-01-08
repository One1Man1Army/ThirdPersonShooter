using System;
using TPS.InternalLogic;
using UnityEngine;

namespace TPS.Player
{
    public sealed class PlayerAnimator : MonoBehaviour
	{
        private static readonly int MoveHash = Animator.StringToHash("Walking");

		[SerializeField] private Animator _animator;
		[SerializeField] private CharacterController _characterController;
        [SerializeField] private RagdollSwitcher _ragdollSwitcher;

		private float _prevFrameVelocity;

        private void Update()
		{
            if (_prevFrameVelocity == _characterController.velocity.magnitude) 
			{
                _animator.SetFloat(MoveHash, 0, 0.1f, Time.deltaTime);
            }
			else
			{
				_animator.SetFloat(MoveHash,1, 0.1f, Time.deltaTime);
			}
            
			_prevFrameVelocity = _characterController.velocity.magnitude;

        }

		public void OnDeath(Transform deathDealer)
		{
			_animator.enabled = false;
			_ragdollSwitcher.SwitchRagdoll(true);
			_ragdollSwitcher.ApplyForceOnDeath(deathDealer);
		}
	}
}