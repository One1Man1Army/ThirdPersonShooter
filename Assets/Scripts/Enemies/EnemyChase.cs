using TPS.InputLogic;
using UnityEngine;
using Zenject;

namespace TPS.Enemies
{
    public sealed class EnemyChase : MonoBehaviour
	{
        [SerializeField] private EnemyMove _follow;

		private IInputService _inputService;

        [Inject]
		public void Construct(IInputService inputService)
		{
			_inputService = inputService;
			_inputService.OnFireButtonDown += ChasePlayer;

			SwitchFollow(false);
		}

		private void ChasePlayer()
		{
			SwitchFollow(true);
        }

		private void SwitchFollow(bool on) => 
			_follow.enabled = on;

        private void OnDestroy()
        {
            _inputService.OnFireButtonDown -= ChasePlayer;
        }
    }
}