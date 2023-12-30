using TPS.Enemies;

namespace TPS.InternalLogic
{
    public interface IEnemiesInitializer
    {
        void SpawnEnemies(EnemySpawner[] enemySpawners);
    }
}