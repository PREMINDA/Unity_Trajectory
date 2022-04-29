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
        [SerializeField]private LineRender render;
        [SerializeField]private float forceMultiplier = 1f;
        
        private Camera _cam;
        private bool _isDragging;
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
            trajectory.Show ();
        }
        private void OnDrag()
        {
            Vector3 ballPos = ball.GetBallPos();
            Vector2 ballPosV2 = new Vector2(ballPos.x, ballPos.y);
            _endPoint = _cam.ScreenToWorldPoint (Input.mousePosition);
            _distance = Vector2.Distance (ballPosV2, _endPoint);
            _direction = (_endPoint - ballPosV2).normalized;
            _force = _direction * _distance * pushForce*forceMultiplier;
            
            trajectory.UpdateDots (ballPos, _force);
            trajectory.Show ();
            render.SetStarEndtPoint(ballPosV2,_endPoint);
            render.SetEnableTrue();
        }
        private void OnDragEnd()
        {
            ball.ActivateRb ();
            ball.Push (_force);
            trajectory.Hide ();
            render.SetEnableFale();
        }

    }
}
