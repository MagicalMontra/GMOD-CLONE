using UnityEngine;
using Cinemachine;
using System;

namespace Gamespace.Core.Blueprint
{
    [Serializable]
    public class BlurprintCameraSettings
    {
        public float moveSpeed = 1f;
        public float zoomSpeed = 2.5f;
        public float maxZoom = 80f;
        public float minZoom = 20f;
        public Camera mainCamera;
        public Camera bluePrintCameraOverlay;
        public CinemachineVirtualCameraBase bluePrintCamera;
       
    }

}