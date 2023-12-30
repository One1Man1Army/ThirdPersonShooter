using TPS.Player;
using UnityEngine;
using Zenject;
using TPS.InputLogic;
using TPS.Enemies;
using TPS.Missiles;
using TPS.VFX;
using TPS.CommonLogic;

namespace TPS.InternalLogic
{
    public sealed class LevelInstaller : MonoInstaller, IInitializable
    {
        #region Fields
        [Header("Spawn Points")]
        [SerializeField] private Transform _playerSpawnPoint;
        [SerializeField] private EnemySpawner[] _enemySpawners;

        private GameData _gameData;
        #endregion

        public override void InstallBindings()
        {
            Resolve();
            BindInstallerInterfaces();
            BindPools();
            BindFactories();
            BindInputService();
            BindPlayer();
        }

        private void Resolve()
        {
            _gameData = Container.Resolve<GameData>();
        }

        #region Pools Bindings
        private void BindPools()
        {
            BindMissilesVFXPool();
            BindEnemyDeathVFXPool();
        }

        private void BindMissilesVFXPool()
        {
            Container.BindMemoryPool<MissileExplodeVFX, MissileExplodeVFX.Pool>()
                .WithInitialSize(2)
                .FromComponentInNewPrefab(_gameData.missileVFXPrefab)
                .UnderTransformGroup("MissilesVFXPool");
        }

        private void BindEnemyDeathVFXPool()
        {
            Container.BindMemoryPool<EnemyDeathVFX, EnemyDeathVFX.Pool>()
                .WithInitialSize(1)
                .FromComponentInNewPrefab(_gameData.enemyDeathVFXPrefab)
                .UnderTransformGroup("EnemyDeathVFXPool");
        }
        #endregion

        #region Factories Bindings
        private void BindFactories()
        {
            BindVFXFactory();
            BindMissilesFactory();
            BindEnemiesFactory();
        }

        private void BindMissilesFactory()
        {
            Container.BindFactory<Vector3, Quaternion, Missile, Missile.Factory>().
                FromMonoPoolableMemoryPool(
                x => x.WithInitialSize(3).
                FromComponentInNewPrefab(_gameData.missilePrefab).
                UnderTransformGroup("MissilesPool"));
        }

        private void BindVFXFactory()
        {
            Container
                .Bind<IVFXFactory>()
                .To<VFXFactory>().AsSingle();
        }

        private void BindEnemiesFactory()
        {
            Container
                .Bind<IEnemiesFactory>()
                .To<EnemiesFactory>()
                .FromInstance(new EnemiesFactory(Container, _gameData.enemiesPrefabs))
                .AsSingle();
        }
        #endregion

        #region Game Entities Bindings
        private void BindPlayer()
        {
            var playerFacade = Container
                .InstantiatePrefabForComponent<PlayerFacade>(_gameData.playerPrefab, _playerSpawnPoint.position, Quaternion.identity, null);

            Container
                .Bind<PlayerFacade>()
                .FromInstance(playerFacade)
                .AsSingle();
        }

        private void BindInputService()
        {
            Container
                .Bind<IInputService>()
                .To<InputService>()
                .FromComponentInNewPrefab(_gameData.inputPrefab)
                .AsSingle();
        }
        #endregion

        #region Initialization
        private void BindInstallerInterfaces()
        {
            Container
                .BindInterfacesTo<LevelInstaller>()
                .FromInstance(this)
                .AsSingle();
        }
        public void Initialize()
        {
            var enemiesInitializer = new EnemiesInitializer(Container.Resolve<IEnemiesFactory>(), _enemySpawners);
            enemiesInitializer.SpawnEnemies();
        }
        #endregion
    }
}
