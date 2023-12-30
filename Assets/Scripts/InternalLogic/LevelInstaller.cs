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

        private GameSettings _gameSettings;
        #endregion

        public override void InstallBindings()
        {
            ResolveGameSettings();
            BindInstallerInterfaces();
            BindPools();
            BindFactories();
            BindInputService();
            BindPlayer();
        }

        private void ResolveGameSettings()
        {
            _gameSettings = Container.Resolve<GameSettings>();
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
                .FromComponentInNewPrefab(_gameSettings.missileVFXPrefab)
                .UnderTransformGroup("MissilesVFXPool");
        }

        private void BindEnemyDeathVFXPool()
        {
            Container.BindMemoryPool<EnemyDeathVFX, EnemyDeathVFX.Pool>()
                .WithInitialSize(1)
                .FromComponentInNewPrefab(_gameSettings.enemyDeathVFXPrefab)
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
                FromComponentInNewPrefab(_gameSettings.missilePrefab).
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
                .FromInstance(new EnemiesFactory(Container, _gameSettings.enemiesPrefabs))
                .AsSingle();
        }
        #endregion

        #region Game Entities Bindings
        private void BindPlayer()
        {
            var playerFacade = Container
                .InstantiatePrefabForComponent<PlayerFacade>(_gameSettings.playerPrefab, _playerSpawnPoint.position, Quaternion.identity, null);

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
                .FromComponentInNewPrefab(_gameSettings.inputPrefab)
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
