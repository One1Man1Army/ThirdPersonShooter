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
        #region Fields
        [SerializeField] private CinemachineFreeLook _cinemachineCam;

        IInputService _inputService;
        #endregion

        [Inject]
        public void Construct(IInputService inputService, PlayerFacade playerFacade)
        {
            _inputService = inputService;
            _cinemachineCam.LookAt = playerFacade.cameraPoint;
            CinemachineCore.GetInputAxis = GetInputAxis;
        }

        private float GetInputAxis(string axisName)
        {
            if (axisName == Constants.RightStickAxisX)
                return _inputService.RightAxis.x;

            return Input.GetAxis(axisName);
        }
    }
}
