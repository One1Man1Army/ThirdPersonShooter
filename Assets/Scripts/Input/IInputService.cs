using System;

namespace TPS.InputLogic
{
    public interface IInputService
    {
        float Vertical { get; }
        float Horizontal { get; }
        event Action OnFireButtonDown;
    }
}
