using UnityEngine;

namespace Fishing2D
{
    public class LevelStartButton : BaseButton
    {
        protected override void OnClick()
        {
            this.OnEvent(eEventType.LevelStart);
        }
    }
}
