using UnityEngine;

namespace Fishing2D
{
    public class UiWindow : MonoBehaviour
    {
        [field: SerializeField] public eWindowType WindowType { get; private set; }

        public void Show() => gameObject.SetActive(true);
        public void Hide() => gameObject.SetActive(false);
    }
}
