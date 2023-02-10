using UnityEngine;
using Zenject;
namespace Fishing2D
{
    public class Fish : MonoBehaviour, ICanGetCaught
    {
        [Inject] private LakeBorder _border;
        [SerializeField] private float _movementSpeed;
        private Vector3 _currentTarget;
        private readonly float _minDistanceToTarget = 0.1f;

        public Transform ObjTransform => transform;
        public bool IsGetCaught { get; private set; }
        private void Awake()
        {
            _currentTarget = GetNewWayTarget();
        }

        public void GetCaught()
        {
            this.OnEvent(eEventType.ObjectInHook,this);
            IsGetCaught = true;
        }   

        private Vector3 GetNewWayTarget()
        {
            var x = Random.Range(_border.Left, _border.Right);
            var y = Random.Range(_border.Top, _border.Bottom);
            return new Vector3(x, y, 0);
        }

        private void Update()
        {
            if (IsGetCaught) return;

            var dist = Vector3.Distance(transform.position, _currentTarget);
            if (dist > _minDistanceToTarget)
            {
                transform.position = Vector3.MoveTowards(transform.position, _currentTarget, Time.deltaTime * _movementSpeed);
                var dir = _currentTarget - transform.position;
                var lScale = transform.localScale;
                
                if (dir.normalized.x >= 0) transform.localScale = new Vector3(Mathf.Abs(lScale.x), Mathf.Abs(lScale.y), lScale.z);
                else transform.localScale = new Vector3(Mathf.Abs(lScale.x), -Mathf.Abs(lScale.y), lScale.z);

                transform.right = Vector3.Lerp(transform.right, dir, Time.deltaTime * _movementSpeed);
            }
            else
            {
                _currentTarget = GetNewWayTarget();
            }
        }

       
    }
}
