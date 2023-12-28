using UnityEngine;
using Zenject;

namespace TPS.InternalLogic
{
    public sealed class EnemiesFactory : IEnemiesFactory
    {
        #region Fields
        private readonly DiContainer _diContainer;

        private readonly GameObject _simpEnemyPrefab;
        private readonly GameObject _bossEnemyPrefab;
        #endregion

        public EnemiesFactory(DiContainer diContainer, GameObject simpEnemyPrefab, GameObject bossEnemyPrefab)
        {
            _diContainer = diContainer;
            _simpEnemyPrefab = simpEnemyPrefab;
            _bossEnemyPrefab = bossEnemyPrefab;
        }


        public void Create(EnemyType type, Vector3 pos, Transform parent)
        {
            switch (type)
            {
                case EnemyType.Simp:
                    _diContainer.InstantiatePrefab(_simpEnemyPrefab, pos, Quaternion.identity, parent);
                    break;
                case EnemyType.Boss:
                    _diContainer.InstantiatePrefab(_bossEnemyPrefab, pos, Quaternion.identity, parent);
                    break;
            }
        }
    }
}
