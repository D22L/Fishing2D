using UnityEngine;
using DG.Tweening;
using Zenject;
namespace Fishing2D
{
    public class HookFishingState : State<HookController>
    {
        private Camera _camera;
        private Vector3 _currentMousePos;
        private readonly float _stopDistance = 0.1f;        
     
        public HookFishingState(HookController targetValue, StateMachine sm) : base(targetValue, sm)
        {
           _camera = Camera.main;
        }

        public override void Enter()
        {
            if (!target.InWater)
            {
                target.transform.DOMove(target.ThorwPointPos, target.ThrowAnimDuration)
                    .SetEase(Ease.Linear)
                    .OnComplete(() =>
                    {
                        target.InWater = true;
                        EventManager.OnEvent(eEventType.HookInWater);
                    });
            }
        }
        
        public override void Update()
        {
            if (!target.InWater) return;
            var inputPos = Input.mousePosition;
            
            if (Input.GetMouseButton(0))
            {
                _currentMousePos = _camera.ScreenToWorldPoint(inputPos);
                var dir = _currentMousePos -  target.transform.position;
                dir.z = target.transform.position.z;
                var targetPos = target.transform.position + dir;
                targetPos.x = Mathf.Clamp(targetPos.x, target.LakeBorder.Left, target.LakeBorder.Right);
                targetPos.y = Mathf.Clamp(targetPos.y, target.LakeBorder.Bottom, target.LakeBorder.Top);

                if (Vector3.Distance(target.transform.position, targetPos) > _stopDistance)
                {
                    target.transform.position = Vector3.MoveTowards(target.transform.position, targetPos, Time.deltaTime * target.MoveSpeed);
                    target.transform.up = -dir.normalized;
                }
            }
        }
    }

}
