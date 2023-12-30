using TPS.InternalLogic;
using TPS.Player;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace TPS.Enemies
{
    public sealed class EnemyMove : MonoBehaviour
    {
        [SerializeField] private float _minimalDistance = 0.25f;
        [SerializeField] private NavMeshAgent _agent;

        private Transform _player;

        [Inject]
        public void Construct(PlayerFacade playerFacade)
        {
             _player = playerFacade.transform;
        }

        private void Update()
        {
            if (IsHeroNotReached())
            {
                if (_player != null)
                {
                    _agent.destination = _player.position;
                }
            }
        }

        private bool IsHeroNotReached() =>
          _agent.transform.position.SqrMagnitudeTo(_player.position) >= _minimalDistance;
    }
}