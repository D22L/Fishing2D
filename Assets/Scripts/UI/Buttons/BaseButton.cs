using UnityEngine;
using UnityEngine.UI;

namespace Fishing2D
{
    [RequireComponent(typeof(Button))]
    public abstract class BaseButton : MonoBehaviour
    {
        protected Button button;
        protected virtual void Awake()
        {
            button = GetComponent<Button>();
            button?.onClick.AddListener(OnClick);
        }

        protected abstract void OnClick();
    }
}
