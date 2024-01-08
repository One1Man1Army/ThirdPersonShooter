using TPS.Player;
using UnityEngine;
using Zenject;
using Cinemachine;
using TPS.InputLogic;
using TPS.InternalLogic;

namespace TPS.CameraLogic
{
    public sealed class CameraRotation : MonoBehaviour
    {
        [SerializeField] private CinemachineFreeLook _cinemachineCam;

        [Inject]
        public void Construct(PlayerFacade playerFacade)
        {
            _cinemachineCam.LookAt = playerFacade.cameraPoint;
        }
    }
}
