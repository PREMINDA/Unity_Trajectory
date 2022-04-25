using UnityEngine;

namespace script
{
    public class Ball : MonoBehaviour
    {
        [HideInInspector] public Rigidbody2D rb;
        [HideInInspector] public CircleCollider2D col;
        [HideInInspector] public Vector3 Pos { get { return transform.position; } }

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            col = GetComponent<CircleCollider2D>();
        }

        public void Push (Vector2 force)
        {
            rb.AddForce (force, ForceMode2D.Impulse);
        }

        public void ActivateRb ()
        {
            rb.isKinematic = false;
        }

        public void DesActivateRb ()
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = 0f;
            rb.isKinematic = true;
        }
    }
}