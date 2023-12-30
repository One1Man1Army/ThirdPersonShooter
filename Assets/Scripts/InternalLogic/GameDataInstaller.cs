using TPS.CommonLogic;
using UnityEngine;
using Zenject;

namespace TPS.InternalLogic
{
    [CreateAssetMenu(fileName = "GameDataInstaller", menuName = "Installers/GameDataInstaller")]
    public sealed class GameDataInstaller : ScriptableObjectInstaller<GameDataInstaller>
    {
        public GameData gameData;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<GameData>().FromInstance(gameData).AsSingle();
        }
    }
}
