using UnityEngine;
using Zenject;

namespace TPS.VFX
{
    public sealed class EnemyDeathVFX : PoolableVFX
    {
        public class Pool : MonoMemoryPool<EnemyDeathVFX>
        {
        }
    }
}
