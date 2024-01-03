using System;
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

            InitEnemiesContainer(enemiesPrefabs);
        }

        public void Create(EnemyType type, Vector3 pos, Transform parent)
        {
            _diContainer.InstantiatePrefab(enemies[type], pos, Quaternion.identity, parent);
        }

        private void InitEnemiesContainer(Enemy[] enemiesPrefabs)
        {
            foreach (Enemy enemy in enemiesPrefabs)
            {
                try
                {
                    enemies.Add(enemy.Type, enemy);
                }
                catch (Exception e)
                {
                    Debug.Log($"Cannot add enemy type to enemies factory! {e.Message}"); ;
                }
                
            }
        }
    }
}
