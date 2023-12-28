using UnityEngine;
using Zenject;

namespace TPS.InternalLogic
{
    public interface IVFXFactory : IFactory
    {
        void Create(VFXType effect, Vector3 pos);
    }
}