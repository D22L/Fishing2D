using UnityEngine;
using DG.Tweening;

namespace Fishing2D
{
    public class OnHookState : State<HookController>
    {
        private readonly float _resetPosDuration = 3f;
        public OnHookState(HookController targetValue, StateMachine sm) : base(targetValue, sm)
        {
        }

        public override void Enter()
        {
            target.transform.up = target.StartRot - target.transform.position;
            target.transform.DOMove(target.StartPos, _resetPosDuration).OnComplete(() => {
                machine.SetState(target.HookIdle);
            });        
        }

    }
}
