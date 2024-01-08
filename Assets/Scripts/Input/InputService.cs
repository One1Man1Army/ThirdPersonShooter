using System;
using TPS.InternalLogic;
using UnityEngine;

namespace TPS.InputLogic
{
    public sealed class InputService : MonoBehaviour, IInputService
    {
        public float Vertical { get; private set; }
        public float Horizontal { get; private set; }

        public event Action OnFireButtonDown;

        void Update()
        { 
            Vertical = Input.GetAxisRaw(Constants.VerticalAxisName);
            Horizontal = Input.GetAxisRaw(Constants.HorizontalAxisName);

            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) 
            {
                OnFireButtonDown?.Invoke();
            }
        }
    }
}
