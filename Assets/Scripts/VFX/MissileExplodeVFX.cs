using UnityEngine;
using Zenject;

namespace TPS.VFX
{
    public sealed class MissileExplodeVFX: PoolableVFX
    {
        public class Pool : MonoMemoryPool<MissileExplodeVFX>
        {
        }
    }
}
