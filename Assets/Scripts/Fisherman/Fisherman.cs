using System;
using UnityEngine;
using Zenject;

namespace Fishing2D
{
    public class Fisherman : MonoBehaviour
    {        
        [field: SerializeField] public Transform StartHookPointInLake { get; private set; }
        [field:SerializeField] public HookController HookController { get; private set; }
        [field: SerializeField] public float ThrowDuration { get; private set; } = 1f;
        
        [Inject] private LevelController _levelController;
        private StateMachine _sm;
        private Bag _bag;
        public FishermanIdleState IdleState { get; private set; }
        public FishermanFishingState FishingState { get; private set; }

        private void Awake()
        {
            _bag = new Bag();
            _sm = new StateMachine();
            IdleState = new FishermanIdleState(this,_sm);
            FishingState = new FishermanFishingState(this,_sm);
            _sm.SetState(IdleState);
        }

        private void OnEnable()
        {
            this.Subscribe(eEventType.CollectFish, OnCollectFish);
            this.Subscribe(eEventType.LevelFail, OnLevelEnd);
        }
 
        private void OnDisable()
        {
            this.Unsubscribe(eEventType.CollectFish, OnCollectFish);
            this.Unsubscribe(eEventType.LevelFail, OnLevelEnd);
        }

        private void OnLevelEnd(object arg0)
        {
            HookController.Stop();
            _sm.Stop();
        }
        private void OnCollectFish(object arg0)
        {
            ICanGetCaught caughtObj = (ICanGetCaught)arg0;
            if (caughtObj != null) _bag.AddObj(caughtObj);

            if (_bag.IsContains(_levelController.LevelConfig.TargetForFishing.sprite))
            {
                this.OnEvent(eEventType.LevelWin);

            }
            else
            {
                HookController.Clear();
                _sm.SetState(IdleState);
            }
        }

        private void Update()
        {
            _sm.CurrentState?.Update();
        }
 
    }
}
