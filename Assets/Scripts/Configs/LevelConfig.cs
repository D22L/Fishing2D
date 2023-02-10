using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fishing2D
{
    [CreateAssetMenu(fileName = "LevelConfig", menuName = "Configs/LevelConfig")]
    public class LevelConfig : ScriptableObject
    {
        [field: SerializeField] public FishSettings TargetForFishing { get; private set; }
        [field: SerializeField] public int CountAttempt { get; private set; }
    }
}
