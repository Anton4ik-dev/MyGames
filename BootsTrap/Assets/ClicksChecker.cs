using UnityEngine;
using ScoreSystem;

namespace Core
{
    public class ClicksChecker : MonoBehaviour
    {
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
    }
}