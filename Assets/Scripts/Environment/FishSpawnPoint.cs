using UnityEngine;
using Zenject;

namespace Fishing2D
{
    public class FishSpawnPoint : MonoBehaviour
    {
        [SerializeField] private Fish _fishPfb;
        [SerializeField] private FishSettings _fishSettings;
        [SerializeField] private int _count;
        [Inject] private DiContainer _diContainer;
        private void Awake()
        {
            for (int i = 0; i < _count; i++)
            {
                var fishObj = _diContainer.InstantiatePrefab(_fishPfb);
                var fish = fishObj.GetComponent<Fish>();
                fish.SetFishSettings(_fishSettings);
                fish.transform.position = transform.position;
            }
        }
    }
}
