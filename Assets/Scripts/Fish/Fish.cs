using UnityEngine;
using Zenject;
namespace Fishing2D
{
    public class Fish : MonoBehaviour, ICanGetCaught
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [Inject] private LakeBorder _border;
        
        private Vector3 _currentTarget;
        private readonly float _minDistanceToTarget = 0.1f;
        private FishSettings _fishSettings;
        public Transform ObjTransform => transform;
        public Sprite SpriteObj => _spriteRenderer.sprite;
        public bool IsGetCaught { get; private set; }
        private void Awake()
        {
            _currentTarget = GetNewWayTarget();
        }

        public void SetFishSettings(FishSettings fs)
        {
            _fishSettings = fs;
            _spriteRenderer.sprite = _fishSettings.sprite;
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
            return new Vector3(x, y, transform.position.z);
        }

        private void Update()
        {
            if (IsGetCaught) return;

            var dist = Vector3.Distance(transform.position, _currentTarget);
            var dir = _currentTarget - transform.position;
            var lScale = transform.localScale;
            if (dir.normalized.x >= 0) transform.localScale = new Vector3(Mathf.Abs(lScale.x), Mathf.Abs(lScale.y), lScale.z);
            else transform.localScale = new Vector3(Mathf.Abs(lScale.x), -Mathf.Abs(lScale.y), lScale.z);

            transform.right = dir.normalized;
            transform.localEulerAngles = new Vector3(0f, 0f, transform.localEulerAngles.z);

            if (dist > _minDistanceToTarget)
            {
                transform.position = Vector3.MoveTowards(transform.position, _currentTarget, Time.deltaTime * _fishSettings.MovementSpeed);                                               
            }
            else
            {
                _currentTarget = GetNewWayTarget();
            }
        }

       
    }
}
