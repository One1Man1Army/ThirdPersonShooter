using TPS.CommonLogic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TPS.Player
{
    public sealed class PlayerDeath : MonoBehaviour
    {
        #region Fields
        [SerializeField] private Health _playerHealth;
        [SerializeField] private PlayerAnimator _playerAnimator;
        [SerializeField] private PlayerMove _playerMove;
        [SerializeField] private PlayerAttack _playerAttack;
        [SerializeField] private CharacterController _characterController;

        [SerializeField] private GameObject _deathFX;
        private bool _isDead;
        #endregion

        private void Start() =>
            _playerHealth.HealthChanged += OnHealthChanged;

        private void OnHealthChanged()
        {
            if (!_isDead && _playerHealth.Current <= 0)
                Die();
        }

        private void Die()
        {
            _isDead = true;
            _playerHealth.HealthChanged -= OnHealthChanged;
            _playerMove.enabled = false;
            _playerAttack.enabled = false;
            _characterController.enabled = false;
            _playerAnimator.OnDeath(_playerHealth.DamageSource);

            Instantiate(_deathFX, transform.position, Quaternion.identity);

            ReloadGame();
        }

        private void OnDestroy() =>
            _playerHealth.HealthChanged -= OnHealthChanged;

        #region SceneManagement
        private void ReloadGame()
        {
            Invoke(nameof(ReloadScene), 3.5f);
        }

        private void ReloadScene()
        {
            SceneManager.LoadScene(0);
        }
        #endregion
    }
}
