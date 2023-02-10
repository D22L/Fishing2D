using UnityEngine;
using DG.Tweening;

namespace Fishing2D
{
    public class Fisherman : MonoBehaviour
    {        
        [field: SerializeField] public Transform StartHookPointInLake { get; private set; }
        [field:SerializeField] public HookController HookController { get; private set; }
        [field: SerializeField] public float ThrowDuration { get; private set; } = 1f;

        private StateMachine _sm;
        public FishermanIdleState IdleState { get; private set; }
        public FishermanFishingState FishingState { get; private set; }

        private void Awake()
        {
            _sm = new StateMachine();
            IdleState = new FishermanIdleState(this,_sm);
            FishingState = new FishermanFishingState(this,_sm);
            _sm.SetState(IdleState);
        }
        private void Update()
        {
            _sm.CurrentState?.Update();
        }
 
    }
}
