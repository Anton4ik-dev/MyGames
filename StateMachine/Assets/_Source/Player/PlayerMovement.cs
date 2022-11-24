using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private Rigidbody2D rb;

        public void MovePlayer(float moveHorizontal, float moveVertical)
        {
            rb.velocity = new Vector2(moveHorizontal * speed, moveVertical * speed);
        }
    }
}