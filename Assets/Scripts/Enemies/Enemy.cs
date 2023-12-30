using TPS.InternalLogic;
using UnityEngine;

namespace TPS.Enemies
{
    public abstract class Enemy : MonoBehaviour
    {
        public abstract EnemyType Type { get; }
    }
}