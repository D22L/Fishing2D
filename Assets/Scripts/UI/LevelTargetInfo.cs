using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Fishing2D
{
    public class LevelTargetInfo : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [Inject] private LevelController _levelController;

        private void OnEnable()
        {
            _image.sprite = _levelController.LevelConfig.TargetForFishing.sprite;
        }

    }
}
