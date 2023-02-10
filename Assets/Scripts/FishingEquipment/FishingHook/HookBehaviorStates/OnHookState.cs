using UnityEngine;
using DG.Tweening;

namespace Fishing2D
{
    public class OnHookState : State<HookController>
    {
        private readonly float _resetPosDuration = 2f;
        public OnHookState(HookController targetValue, StateMachine sm) : base(targetValue, sm)
        {
        }

        public override void Enter()
        {
            target.Bubble.gameObject.SetActive(true);
            target.transform.up = target.StartRot - target.transform.position;
            target.transform.DOMove(target.StartPos, _resetPosDuration)
                .SetEase(Ease.Linear)
                .OnComplete(() => {
                    EventManager.OnEvent(eEventType.TargetOutOfWater, target.CurrentTarget);
                    machine.SetState(target.HookIdle);
                    target.Bubble.gameObject.SetActive(false);
                });        
        }

    }
}
