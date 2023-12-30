using TPS.CommonLogic;
using Zenject;

namespace TPS.Player
{
    public sealed class PlayerHealth : Health
    {
        [Inject]
        public void Construct(GameSettings gameSettings)
        {
            InitializeHP(gameSettings);
        }

        internal override void InitializeHP(GameSettings gameSettings)
        {
            SetValues(gameSettings.playerHP);
        }
    }
}
