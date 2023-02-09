using UnityEngine;

namespace Fishing2D
{
    public class Fisherman : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        private readonly string _startFishingAnimState = "fishing";
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                StartFishing();
            }
        }

        private void StartFishing()
        {
            _animator.Play(_startFishingAnimState);
        }
    }
}
