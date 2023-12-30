using TPS.InternalLogic;

namespace TPS.Enemies
{
    public sealed class EnemySimple : Enemy
    {
        public override EnemyType Type => EnemyType.Simple;
    }
}