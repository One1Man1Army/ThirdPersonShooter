using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TPS.InputLogic
{
    public sealed class InputService : MonoBehaviour, IInputService
    {
        #region Fields
        [SerializeField] private UltimateJoystick _leftStick;
        [SerializeField] private UltimateJoystick _rightStick;
        [SerializeField] private Button _fireButton;

        public Vector2 LeftAxis => _leftAxis;
        public Vector2 RightAxis => _rightAxis;
        public event Action OnFireButtonDown;

        private Vector2 _leftAxis;
        private Vector2 _rightAxis;
        #endregion

        void Awake()
        {
            _fireButton.onClick.AddListener(() => OnFireButtonDown?.Invoke());
        }

        void Update()
        {
            _leftAxis = new Vector2(_leftStick.HorizontalAxis, _leftStick.VerticalAxis);
            _rightAxis = new Vector2(_rightStick.HorizontalAxis, _rightStick.VerticalAxis);
        }
    }
}
