using UnityEngine;
using DG.Tweening;

namespace Fishing2D
{
    public class HookController : MonoBehaviour
    {
        [field:SerializeField] public float MoveSpeed { get; private set; }

        private StateMachine _sm;
        public Vector3 ThorwPointPos { get; private set; }
        public float ThrowAnimDuration { get; private set; }
        public HookIdleState HookIdleState { get; private set; }
        public HookFishingState HookFishingState { get; private set; }
        private void Awake()
        {
            _sm = new StateMachine();
            HookIdleState = new HookIdleState(this,_sm);
            HookFishingState = new HookFishingState(this,_sm);
            _sm.SetState(HookIdleState);
        }

        public void Throw(Vector3 pos, float animDuration)
        {
            ThorwPointPos = pos;
            ThrowAnimDuration = animDuration;

            _sm.SetState(HookFishingState);
        }

        private void Update()
        {
            _sm.CurrentState?.Update();
        }

    }
}
