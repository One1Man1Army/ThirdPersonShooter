using TPS.Enemies;
using UnityEngine;

namespace TPS.InternalLogic
{
    public sealed class EnemiesInitializer
    {
        private readonly IEnemiesFactory _enemiesFactory;
        private readonly EnemySpawner[] _enemySpawners;
        private readonly Transform _enemiesRoot;

        public EnemiesInitializer(IEnemiesFactory enemiesFactory, EnemySpawner[] enemySpawners) 
        {
            _enemiesFactory = enemiesFactory;
            _enemySpawners = enemySpawners;

            if (_enemiesRoot == null)
                _enemiesRoot = GameObject.Instantiate(new GameObject("EnemiesRoot")).transform;
        }

        public void SpawnEnemies()
        {
            foreach (var spawner in _enemySpawners)
            {
                _enemiesFactory.Create(spawner.EnemyType, spawner.transform.position, _enemiesRoot);
            }
        }
    }
}
