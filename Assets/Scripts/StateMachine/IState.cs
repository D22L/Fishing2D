using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fishing2D
{
    public abstract class State<T>: State
    {
        protected T target;
        public State(T targetValue, StateMachine sm)
        {
            target = targetValue;
            machine = sm;
        }
  
    }

    public abstract class State
    {
        protected StateMachine machine;
        public virtual void Enter() { }
        public virtual void Exit() { }
        public virtual void Update() { }
    }
}
