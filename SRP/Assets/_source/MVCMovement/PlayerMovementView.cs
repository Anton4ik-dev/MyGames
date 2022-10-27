using UnityEngine;

namespace MVCMovement
{
    public class PlayerMovementView : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rb;
        public void UpdatePlayerView(Vector2 newVector)
        {
            _rb.velocity = newVector;
        }
    }
}