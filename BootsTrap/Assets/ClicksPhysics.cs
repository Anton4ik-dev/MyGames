using UnityEngine;
using ScoreSystem;

namespace Core
{
    public class ClicksPhysics : MonoBehaviour
    {
        private Rigidbody rb;
        private Score score;
        public Score Score
        {
            get => score;
            set
            {
                score = value;
            }
        }
        private void OnMouseOver()
        {
            if (Input.GetMouseButtonDown(0))
            {
                score.PlayerScore++;
            }
        }
        private void Start()
        {
            rb = GetComponent<Rigidbody>();
            rb.AddForce(Vector3.right * 10, ForceMode.Impulse);
        }
    }
}