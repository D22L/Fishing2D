using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fishing2D
{
    public class CollectFishButton : BaseButton
    {
        private ICanGetCaught _caughtObj;
        public void SetCaughtObj(ICanGetCaught obj)
        {
            _caughtObj = obj;
        }
        protected override void OnClick()
        {
            this.OnEvent(eEventType.CollectFish, _caughtObj);
        }
    }
}
