using System;
using UnityEngine;

namespace TPS.CommonLogic
{
    [Serializable]
    public sealed class GameSettings
    {
        [Header("Player")]
        public float playerHP = 1f;
        public float playerMoveSpeed = 16f;
        public float playerTurnSmoothTime = 0.1f;
        [Min(0.1f)]
        public float playerAttackCooldown = 1f;
        public float playerForceOnDeath = 1000f;
        public float playerForceOnDeathRadius = 2000f;

        [Header("Missile")]
        public float missileSelfDestroyTime = 3f;
        public float missileDamage = 1f;
        public float missileDamageRadius = 2f;
        public float missileSpeed = 48f;

        [Header("Enemies")]
        public float simpleEnemyHP = 1f;
        public float bossEnemyHP = 1f;
    }
}
