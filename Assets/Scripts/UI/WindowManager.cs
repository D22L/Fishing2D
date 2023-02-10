using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fishing2D
{
    public class WindowManager : MonoBehaviour
    {
        [SerializeField] private eWindowType _startWindow;
        [SerializeField] private List<UiWindow> _uiWindows = new List<UiWindow>();
        [SerializeField] private List<UIPopupWindow> _uiPopupWindows = new List<UIPopupWindow>();

        private UiWindow _currentWindow;
        private void OnEnable()
        {
            ShowWindow(_startWindow);
            this.Subscribe(eEventType.LevelStart, OnLevelStart);
            this.Subscribe(eEventType.LevelFail, OnLevelFail);
            this.Subscribe(eEventType.LevelWin, OnLevelWin);
            this.Subscribe(eEventType.TargetOutOfWater, OnTargetOutOfWater);
        }

        private void OnTargetOutOfWater(object arg0)
        {
            ICanGetCaught canGetCaught = (ICanGetCaught)arg0;
            var popup = _uiPopupWindows.Find(x=>x.WindowType == eWindowType.popupWithResult);
            popup?.Show(canGetCaught);
        }

        private void OnLevelWin(object arg)
        {
            ShowWindow(eWindowType.win);
        }

        private void OnLevelFail(object arg)
        {
            ShowWindow(eWindowType.fail);
        }

        private void OnLevelStart(object arg)
        {
            ShowWindow(eWindowType.game);
        }

        private void OnDisable()
        {
            this.Unsubscribe(eEventType.LevelStart, OnLevelStart);
            this.Unsubscribe(eEventType.LevelFail, OnLevelFail);
            this.Unsubscribe(eEventType.LevelWin, OnLevelWin);
            this.Unsubscribe(eEventType.TargetOutOfWater, OnTargetOutOfWater);
        }

        private void ShowWindow(eWindowType windowType)
        {
            var window = _uiWindows.Find((x)=>x.WindowType == windowType);
            _currentWindow?.Hide();
            _currentWindow = window;
            _currentWindow?.Show();
        }
    }
}
