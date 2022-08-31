using UnityEngine;

namespace Sources.Jumping
{
    public class JumpTrajectory : MonoBehaviour
    {
        [SerializeField] private LineRenderer _lineRenderer;
        [SerializeField] private Color _lowPowerColor;
        [SerializeField] private Color _highPowerColor;
        
        private Camera _camera;
        
        private bool IsVisible
        {
            get => _lineRenderer.enabled;
            set => _lineRenderer.enabled = value;
        }
        
        private void Awake()
        {
            _camera = Camera.main;
            InitLineRenderer();
            HideTrajectory();
        }

        public void ShowTrajectory()
        {
            IsVisible = true;
        }

        public void HideTrajectory()
        {
            IsVisible = false;
        }
        
        public void Draw(Vector3 hitPoint)
        {
            PlaceTrajectoryVertices(hitPoint);
            ColorizeTrajectory();
        }
        
        private void InitLineRenderer()
        {
            // PlaceTrajectoryVertices(Vector3.zero);
            
            _lineRenderer.startWidth = .5f;
            _lineRenderer.endWidth = 0;
        }
        
        private void PlaceTrajectoryVertices(Vector3 hitPoint)
        {
            _lineRenderer.SetPositions(GetTrajectoryVertices(hitPoint));
        }

        private Vector3[] GetTrajectoryVertices(Vector3 hitPoint)
        {
            return new[]
            {
                transform.position,
                hitPoint,
            };
        }
        
        private void ColorizeTrajectory()
        {
            float length = Vector3.Distance(_lineRenderer.GetPosition(0), _lineRenderer.GetPosition(1));
            float interpolationValue = Sigmoid(length, 3f, 10f);
            _lineRenderer.startColor = Color.Lerp(_lowPowerColor, _highPowerColor, interpolationValue);
        }

        private float Sigmoid(float x, float width, float offset)
        {
            return 1f / (1f + Mathf.Exp(-width * (x - offset)));
        }
    }
}
