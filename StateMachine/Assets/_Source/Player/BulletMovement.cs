using UnityEngine;

namespace Player
{
    public class BulletMovement : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private Rigidbody2D rb;

        private void Update()
        {
            rb.velocity = new Vector2(speed, Vector3.zero.y);
        }
    }
}