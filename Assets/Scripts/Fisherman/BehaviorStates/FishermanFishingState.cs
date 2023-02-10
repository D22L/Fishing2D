using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fishing2D
{
    public class FishermanFishingState : State<Fisherman>
    {
        public FishermanFishingState(Fisherman targetValue, StateMachine sm) : base(targetValue, sm)
        {
        }

    }
}
