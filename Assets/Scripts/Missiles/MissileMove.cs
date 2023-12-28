using TPS.CommonLogic;
using UnityEngine;
using Zenject;

namespace TPS.Missiles
{
    public sealed class MissileMove : MonoBehaviour
    {
        private float _speed;

        [Inject]
        public void Construct(GameSettings gameSettings)
        {
            _speed = gameSettings.missileSpeed;
        }

        private void Update()
        {
            transform.Translate(Vector3.forward * _speed * Time.deltaTime);
        }
    }
}
