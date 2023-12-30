using System.Collections.Generic;
using TPS.Enemies;
using UnityEngine;
using Zenject;

namespace TPS.InternalLogic
{
    public sealed class EnemiesFactory : IEnemiesFactory
    {
        #region Fields
        private readonly DiContainer _diContainer;

        private readonly Dictionary<EnemyType, Enemy> enemies = new();
        #endregion

        public EnemiesFactory(DiContainer diContainer, Enemy[] enemiesPrefabs)
        {
            _diContainer = diContainer;

            InitEnemies(enemiesPrefabs);
        }

        public void Create(EnemyType type, Vector3 pos, Transform parent)
        {
            _diContainer.InstantiatePrefab(enemies[type], pos, Quaternion.identity, parent);
        }

        private void InitEnemies(Enemy[] enemiesPrefabs)
        {
            foreach (Enemy enemy in enemiesPrefabs)
            {
                enemies.Add(enemy.Type, enemy);
            }
        }
    }
}
