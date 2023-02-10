using DG.Tweening;
using UnityEngine;

namespace Fishing2D
{
    public class HookСommitState : HookFishingState
    {
        private readonly float _fillDuration = 3f;
        private readonly float _minDistanceToCaught = 1f;
        private DOTween _tween;
        public HookСommitState(HookController targetValue, StateMachine sm) : base(targetValue, sm)
        {
        }

        public override void Enter()
        {
             target.ProgressBarImage.DOFillAmount(1f, _fillDuration)
                .OnComplete(() =>
                {
                    target.CurrentTarget.GetCaught();
                    target.CurrentTarget.ObjTransform.parent = target.CaughtPoint;
                    target.CurrentTarget.ObjTransform.DOLocalMove(Vector3.zero,0.5f);
                    target.CurrentTarget.ObjTransform.DOLocalRotate(Vector3.zero,0.1f);
                    target.CurrentTarget.ObjTransform.DOScale(Vector3.one,0.1f);
                    
                    machine.SetState(target.OnHook);
                });           
        }

        public override void Exit()
        {
            target.ProgressBarImage.fillAmount = 0f;
            target.ProgressBarImage.DOKill();
        }

        public override void Update()
        {
            base.Update();
            var dist = Vector3.Distance(target.transform.position, target.CurrentTarget.ObjTransform.position);            
            if (dist > _minDistanceToCaught)
            {
                target.CurrentTarget = null;
                machine.SetState(target.HookFishing);
                EventManager.OnEvent(eEventType.TargetRunAway);
            }          
        }
    }
}
