using TPS.CommonLogic;
using UnityEngine;
using Zenject;

namespace TPS.InternalLogic
{
    [CreateAssetMenu(fileName = "SettingsInstaller", menuName = "Installers/SettingsInstaller")]
    public sealed class SettingsInstaller : ScriptableObjectInstaller<SettingsInstaller>
    {
        public GameSettings gameSettings;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<GameSettings>().FromInstance(gameSettings).AsSingle();
        }
    }
}
