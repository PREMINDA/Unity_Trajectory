using UnityEngine;
using UnityEngine.Serialization;

namespace script
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        public Trajectory trajectory;
        
        [SerializeField]private float pushForce = 4f;
        [SerializeField]private Ball ball;

        private Camera _cam;
        private bool _isDragging;
        private Vector2 _startPoint;
        private Vector2 _endPoint;
        private Vector2 _direction;
        private Vector2 _force;
        private float _distance;
    
        void Awake ()
        {
            if (Instance == null) {
                Instance = this;
            }
        }
        void Start()
        {
            _cam = Camera.main;
            ball.DesActivateRb ();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown (0)) {
                _isDragging = true;
                OnDragStart ();
            }
            if (Input.GetMouseButtonUp (0)) {
                _isDragging = false;
                OnDragEnd ();
            }

            if (_isDragging) {
                OnDrag ();
            }
        }
        private void OnDragStart()
        {
            ball.DesActivateRb ();
            _startPoint = _cam.ScreenToWorldPoint (Input.mousePosition);
            trajectory.Show ();
        }
        private void OnDrag()
        {
            
            _endPoint = _cam.ScreenToWorldPoint (Input.mousePosition);
            _distance = Vector2.Distance (_startPoint, _endPoint);
            _direction = (_startPoint - _endPoint).normalized;
            _force = _direction * _distance * pushForce;
            
            trajectory.UpdateDots (ball.Pos, _force);
            trajectory.Show ();
        }
        private void OnDragEnd()
        {
            ball.ActivateRb ();
            ball.Push (_force);
            trajectory.Hide ();
        }

        
    }
}
