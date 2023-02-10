using UnityEngine;
using Zenject;

namespace Fishing2D
{
    public class LakeBorderInstaller : MonoInstaller
    {
        [SerializeField] private Transform _lake;
        public override void InstallBindings()
        {
            Container.Bind<LakeBorder>().FromMethod(() => new LakeBorder(_lake)).AsSingle().NonLazy();
        }
    }

    public struct LakeBorder
    {
        public float Left { get; private set; }
        public float Right { get; private set; }
        public float Top { get; private set; }
        public float Bottom { get; private set; }

        public LakeBorder(Transform _lake)
        {
            this.Left = _lake.transform.position.x - _lake.transform.localScale.x * 0.5f;
            this.Right = _lake.transform.position.x + _lake.transform.localScale.x * 0.5f;
            this.Top = _lake.transform.position.y + _lake.transform.localScale.y * 0.5f;
            this.Bottom = _lake.transform.position.y - _lake.transform.localScale.y * 0.5f;
        }
    }
}
