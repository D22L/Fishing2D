using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Fishing2D
{
    public class HookController : MonoBehaviour
    {
        [field:SerializeField] public float MoveSpeed { get; private set; }
        [field: SerializeField] public Image ProgressBarImage { get; private set; }
        [field: SerializeField] public Transform CaughtPoint { get; private set; }
        [field: SerializeField] public GameObject Bubble { get; private set; }
        [Inject] public LakeBorder LakeBorder { get; private set; }
        private StateMachine _sm;
        public Vector3 ThorwPointPos { get; private set; }
        public float ThrowAnimDuration { get; private set; }
        public HookIdleState HookIdle { get; private set; }
        public HookFishingState HookFishing { get; private set; }
        public Hook—ommitState Hook—ommit { get; private set; }
        public OnHookState OnHook { get; private set; }
        public ICanGetCaught CurrentTarget { get; set; }
        public Vector3 StartPos { get; private set; }
        public Vector3 StartRot { get; private set; }
        public bool InWater { get; set; }
        private void Awake()
        {
            StartPos = transform.position;
            StartRot = transform.eulerAngles;

            _sm = new StateMachine();
            HookIdle = new HookIdleState(this,_sm);
            HookFishing = new HookFishingState(this,_sm);
            Hook—ommit = new Hook—ommitState(this,_sm);
            OnHook = new OnHookState(this,_sm);
            _sm.SetState(HookIdle);
        }

        public void Stop()
        {
            _sm.Stop();
        }

        public void Clear()
        {
            CurrentTarget.ObjTransform.gameObject.SetActive(false);
            CurrentTarget = null;
        }

        public void Throw(Vector3 pos, float animDuration)
        {
            ThorwPointPos = pos;
            ThrowAnimDuration = animDuration;

            _sm.SetState(HookFishing);
        }
                
        private void Update()
        {
            _sm.CurrentState?.Update();
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (CurrentTarget != null || _sm.CurrentState ==null) return;

            if (other.TryGetComponent(out ICanGetCaught caught))
            {                
                CurrentTarget = caught;
                _sm.SetState(Hook—ommit);
            }
        }
    }
}
