using UnityEngine;
using DG.Tweening;

namespace Fishing2D
{
    public class HookIdleState : State<HookController>
    {
        private Vector3 _startPos;
        private Vector3 _startRot;
        private readonly float _animDuration;
        public HookIdleState(HookController targetValue, StateMachine sm) : base(targetValue, sm)
        {
            _startPos = target.transform.position;
            _startRot = target.transform.eulerAngles;
        }
        public override void Enter()
        {
            target.transform.DOMove(_startPos, _animDuration);
            target.transform.DORotate(_startRot, _animDuration);
        }
        
    }
}
