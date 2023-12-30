using System;
using TPS.Enemies;
using UnityEngine;

namespace TPS.CommonLogic
{
    [Serializable]
    public class GameData
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
    }
}