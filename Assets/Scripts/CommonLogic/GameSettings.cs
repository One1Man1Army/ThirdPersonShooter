using System;
using TPS.Enemies;
using UnityEngine;

namespace TPS.CommonLogic
{
    [Serializable]
    public sealed class GameSettings
    {
        [Header("Prefabs")]

        [Header("Player")]
        public GameObject inputPrefab;
        public GameObject playerPrefab;
        public GameObject missilePrefab;

        [Header("Enemies")]
        public Enemy[] enemiesPrefabs;

        [Header("VFX")]
        public GameObject missileVFXPrefab;
        public GameObject enemyDeathVFXPrefab;

        [Header("Settings")]

        [Header("Player")]
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
    }
}
