using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fishing2D
{
    public class LevelController : MonoBehaviour
    {
        [field: SerializeField] public LevelConfig LevelConfig { get; private set; }
        private int _numberAttempt;
        private void OnEnable()
        {
            this.Subscribe(eEventType.TargetRunAway, OnTargetRunAway);
        }

        private void OnTargetRunAway(object arg0)
        {
            _numberAttempt++;
            if (_numberAttempt >= LevelConfig.CountAttempt) this.OnEvent(eEventType.LevelFail);
        }

        private void OnDisable()
        {
            this.Unsubscribe(eEventType.TargetRunAway, OnTargetRunAway);
        }
    }
}
