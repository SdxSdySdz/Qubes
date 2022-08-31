using Sources.Services.Input;
using UnityEngine;

namespace Sources.Jumping
{
    public class JumpingProvider : MonoBehaviour
    {
        [SerializeField] private InputService _inputService;
        [SerializeField] private PlayerMover _mover;
        [SerializeField] private JumpTrajectory _jumpTrajectory;
        [SerializeField] private TimeSlower _timeSlower;
        [SerializeField] private Shockwave _shockwavePrefab;
        
        private Camera _camera;
        private Vector3 _lastHitPoint;
        
        private void Awake()
        {
            _camera = Camera.main;
        }        
        
        private void OnEnable()
        {
            _inputService.MouseButtonUp += OnMouseButtonUp;
            _inputService.MouseButtonDown += OnMouseButtonDown;
        }

        private void OnDisable()
        {
            _inputService.MouseButtonUp -= OnMouseButtonUp;
            _inputService.MouseButtonDown -= OnMouseButtonDown;
        }
        
        private void Update()
        {
            if (_inputService.IsMouseButtonHeld == false)
                return;

            _jumpTrajectory.Draw(_lastHitPoint);
        }
        
        private void FixedUpdate()
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            
            foreach (var hit in Physics.RaycastAll(ray))
            {
                if (hit.collider.TryGetComponent(out Floor _))
                    _lastHitPoint = hit.point;
            }
        }

        private void OnMouseButtonUp()
        {
            Vector3 moverPosition = _mover.transform.position;
            Vector2 direction = new Vector2(_lastHitPoint.x - moverPosition.x, _lastHitPoint.z - moverPosition.z);
            
            _mover.Jump(direction);
            _timeSlower.NormalizeTime();
            _jumpTrajectory.HideTrajectory();
            
            Shockwave shockwave = Instantiate(_shockwavePrefab, transform.position, Quaternion.identity);
            shockwave.Explode(new Vector3(direction.x, 0, direction.y));
        }
        
        private void OnMouseButtonDown()
        {
            _timeSlower.SlowTime();
            _jumpTrajectory.ShowTrajectory();
        }
    }
}
