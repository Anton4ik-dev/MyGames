using UnityEngine.UI;
using UnityEngine;
using ScoreSystem;
using UnityEngine.Events;

namespace Core
{
    public class TextUploader : MonoBehaviour
    {
        private const string SCORE_TEXT = "Score : ";
        private Text text;
        private Score score;
        public UnityAction m_action;
        public Score Score
        {
            get => score;
            set
            {
                score = value;
            }
        }
        private void Awake()
        {
            text = GetComponent<Text>();
            m_action += ChangeScore;
        }
        void ChangeScore()
        {
            text.text = SCORE_TEXT + score.PlayerScore;
        }
    }
}