using TPS.CommonLogic;
using TPS.InternalLogic;

namespace TPS.Enemies
{
    public sealed class EnemyBoss : Enemy
    {
        public override EnemyType Type => EnemyType.Boss;
    }
}