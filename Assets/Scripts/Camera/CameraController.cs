using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System;

namespace Fishing2D
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera _startVC;
        [SerializeField] private CinemachineVirtualCamera _hookVC;

        private CinemachineVirtualCamera _currentVC;
        private void OnEnable()
        {
            this.Subscribe(eEventType.HookInWater, OnHookInWater);
            SetCurrentVC(_startVC);
        }

        private void SetCurrentVC(CinemachineVirtualCamera vc)
        {
            if(_currentVC!=null) _currentVC.Priority = 0;
            _currentVC = vc;
            _currentVC.Priority = 1;
        }
        private void OnHookInWater(object arg0)
        {
            SetCurrentVC(_hookVC);
        }

        private void OnDisable()
        {
            this.Unsubscribe(eEventType.HookInWater, OnHookInWater);
        }
    }
}
