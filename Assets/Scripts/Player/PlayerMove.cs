using TPS.CommonLogic;
using TPS.InputLogic;
using UnityEngine;
using Zenject;

namespace TPS.Player
{
    public sealed class PlayerMove : MonoBehaviour
    {
        [SerializeField] private CharacterController _characterController;

        private IInputService _inputService;
        private Camera _camera;

        private float _speed;
        private float _turnSmoothTime;

        private float _turnSmoothVelocity;

        [Inject]
        public void Construct(IInputService inputService, GameSettings gameSettings)
        {
            _inputService = inputService;
            _camera = Camera.main;

            _speed = gameSettings.playerMoveSpeed;
            _turnSmoothTime = gameSettings.playerTurnSmoothTime;
        }

        private void Update()
        {
            var direction = new Vector3(_inputService.Horizontal, 0f, _inputService.Vertical).normalized;

            if (direction.magnitude >= 0.1f)
            {
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + _camera.transform.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _turnSmoothVelocity, _turnSmoothTime);
                transform.rotation = Quaternion.Euler(0, angle, 0);

                Vector3 moveDir = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
                _characterController.Move(moveDir.normalized * _speed * Time.deltaTime);
            }
        }
    }
}