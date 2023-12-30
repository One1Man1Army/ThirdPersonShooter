using TPS.CommonLogic;
using TPS.InternalLogic;
using UnityEngine;
using Zenject;

namespace TPS.Enemies
{
    public sealed class EnemyHealth : Health
    {
        [SerializeField] private Enemy _self;

        [Inject]
        public void Construct(GameSettings gameSettings)
        {
            InitializeHP(gameSettings);
        }

        internal override void InitializeHP(GameSettings gameSettings)
        {
            switch (_self.Type)
            {
                case EnemyType.Simple:
                    SetValues(gameSettings.simpleEnemyHP);
                    break;
                case EnemyType.Boss:
                    SetValues(gameSettings.bossEnemyHP);
                    break;
            }
        }
    }
}