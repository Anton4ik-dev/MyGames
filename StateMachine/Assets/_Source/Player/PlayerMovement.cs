using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private Rigidbody2D rb;

        public void MovePlayer(float moveHorizontal, float moveVertical)
        {
            rb.velocity = Vector2.ClampMagnitude(new Vector2(moveHorizontal, moveVertical), 1f) * speed;
        }
    }
}