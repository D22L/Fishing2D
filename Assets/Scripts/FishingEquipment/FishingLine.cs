using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fishing2D
{
    [RequireComponent(typeof(LineRenderer))]
    public class FishingLine : MonoBehaviour
    {
        [SerializeField] private Transform _startPoint;
        [SerializeField] private Transform _endPoint;

        private LineRenderer _lineRenderer;
        private Vector3[] _positions;
        private void Awake()
        {
            _lineRenderer = GetComponent<LineRenderer>();
            _positions = new Vector3[2];
            _positions[0] = _startPoint.position;
        }

        private void Update()
        {
            _positions[1] = _endPoint.position;
            _lineRenderer.SetPositions(_positions);
        }
    }
}
