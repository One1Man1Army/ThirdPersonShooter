using TPS.Player;
using UnityEngine;
using Zenject;
using Cinemachine;

namespace TPS.CameraLogic
{
    public sealed class CameraFollow : MonoBehaviour
    {
        #region Fields
        [SerializeField] private CinemachineFreeLook _cinemachineCam;
        #endregion

        [Inject]
        public void Construct(PlayerFacade playerFacade)
        {
            _cinemachineCam.Follow = playerFacade.cameraPoint;
        }
    }
}
