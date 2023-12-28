using UnityEngine;
using Zenject;

namespace TPS.InternalLogic
{
    public interface IEnemiesFactory : IFactory
    {
        void Create(EnemyType effect, Vector3 pos, Transform parent);
    }
}