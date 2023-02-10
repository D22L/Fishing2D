using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fishing2D
{
    [CreateAssetMenu(fileName = "FishSettings", menuName = "Configs/FishSettings")]
    public class FishSettings : ScriptableObject
    {
        [field: SerializeField] public float MovementSpeed { get; private set; }
        [field: SerializeField] public Sprite sprite { get; private set; }
    }
}
