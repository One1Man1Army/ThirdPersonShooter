using TPS.CommonLogic;
using TPS.InputLogic;
using TPS.InternalLogic;
using UnityEngine;
using Zenject;

namespace TPS.Player
{
    public sealed class PlayerMove : MonoBehaviour
    {
        #region Fields
        [SerializeField] private CharacterController _characterController;

        private IInputService _inputService;
        private Camera _camera;

        private float _movementSpeed;
        private float _turnSmoothTime;

        private float _turnSmoothVelocity;
        #endregion

        [Inject]
        public void Construct(IInputService inputService, GameSettings gameSettings)
        {
            _inputService = inputService;
            _camera = Camera.main;

            _movementSpeed = gameSettings.playerMoveSpeed;
            _turnSmoothTime = gameSettings.playerTurnSmoothTime;
        }

        private void Update()
        {
            if (IsLeftStickMoved())
            {
                var direction = new Vector3(_inputService.LeftAxis.x, 0f, _inputService.LeftAxis.y).normalized;

                if (direction.magnitude <= Constants.Epsilon)
                    return;

                var targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + _camera.transform.eulerAngles.y;

                Rotate(targetAngle);
                Move(targetAngle);
            }
            else
            {
                Stop();
            }
        }

        private void Stop()
        {
            _characterController.SimpleMove(Vector3.zero);
        }

        private void Rotate(float targetAngle)
        {
            var angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _turnSmoothVelocity, _turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
        }

        private void Move(float targetAngle)
        {
            var moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            _characterController.Move(moveDir.normalized * _movementSpeed * Time.deltaTime);
        }

        private bool IsLeftStickMoved()
        {
            return _inputService.LeftAxis.sqrMagnitude > Constants.Epsilon;
        }
    }
}