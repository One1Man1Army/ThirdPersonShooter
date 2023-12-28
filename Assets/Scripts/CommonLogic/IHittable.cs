using UnityEngine;

namespace TPS.CommonLogic
{
    public interface IHittable
    {
        void TakeHit(float damage, Transform damageSource);
    }
}
