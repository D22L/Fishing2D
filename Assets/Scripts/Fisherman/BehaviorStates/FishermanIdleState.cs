using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fishing2D
{
    public class FishermanIdleState :State<Fisherman>
    {
        public FishermanIdleState(Fisherman targetValue, StateMachine sm) : base(targetValue, sm)
        {

        }

        public override void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                target.HookController.Throw(target.StartHookPointInLake.position, target.ThrowDuration);
                machine.SetState(target.FishingState);
            }
        }
    }
}
