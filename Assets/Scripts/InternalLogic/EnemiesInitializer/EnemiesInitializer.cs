using TPS.Enemies;
using UnityEngine;

namespace TPS.InternalLogic
{
    public sealed class EnemiesInitializer : IEnemiesInitializer
    {
        private readonly IEnemiesFactory _enemiesFactory;

        private Transform _enemiesRoot;

        public EnemiesInitializer(IEnemiesFactory enemiesFactory)
        {
            _enemiesFactory = enemiesFactory;
        }

        public void SpawnEnemies(EnemySpawner[] enemySpawners)
        {
            CreateRoot();

            foreach (var spawner in enemySpawners)
            {
                _enemiesFactory.Create(spawner.EnemyType, spawner.transform.position, _enemiesRoot);
            }
        }

        private void CreateRoot()
        {
            if( _enemiesRoot == null)
                _enemiesRoot = new GameObject("EnemiesRoot").transform;
        }
    }
}
