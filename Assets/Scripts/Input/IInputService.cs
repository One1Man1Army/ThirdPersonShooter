using System;
using UnityEngine;

namespace TPS.InputLogic
{
    public interface IInputService
    {
        Vector2 LeftAxis { get; }
        Vector2 RightAxis { get; }
        public event Action OnFireButtonDown;
    }
}
