using TPS.CommonLogic;
using TPS.InputLogic;
using TPS.Missiles;
using UnityEngine;
using Zenject;

namespace TPS.Player
{
    public sealed class PlayerAttack : MonoBehaviour
    {
        #region Fields
        [SerializeField] private MissilesLauncher _missilesLauncher;

        private IInputService _inputService;

        private float _cooldown;

        private float _cooldownTimer;
        #endregion

        [Inject]
        public void Construct(IInputService inputService, GameSettings gameSettings)
        {
            _inputService = inputService;
            _inputService.OnFireButtonDown += FireMissile;

            _cooldown = gameSettings.playerAttackCooldown;
        }

        void Update()
        {
            ResetCooldownTimer();
        }

        private void FireMissile()
        {
            if (_cooldownTimer < _cooldown)
                return;

            _cooldownTimer = 0;

            _missilesLauncher.SpawnMissile();
        }

        private void ResetCooldownTimer()
        {
            if (_cooldownTimer < _cooldown)
                _cooldownTimer += Time.deltaTime;
        }

        private void OnDestroy()
        {
            _inputService.OnFireButtonDown -= FireMissile;
        }
    }
}