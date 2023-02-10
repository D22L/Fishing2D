using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fishing2D
{
    public class StateMachine
    {
       public State CurrentState { get; private set; }

        public void SetState(State state)
        {
            CurrentState?.Exit();
            CurrentState = state;
            CurrentState.Enter();
        }
    }
}
