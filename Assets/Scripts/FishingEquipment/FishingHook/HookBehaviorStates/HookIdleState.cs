using UnityEngine;
using DG.Tweening;

namespace Fishing2D
{
    public class HookIdleState : State<HookController>
    {
       
        private readonly float _animDuration = 1f;
        public HookIdleState(HookController targetValue, StateMachine sm) : base(targetValue, sm)
        {          
        }
        public override void Enter()
        {            
            target.transform.DORotate(target.StartRot, _animDuration);
            target.InWater = false;         
        }
        
    }
}
