using UnityEngine.Events;
using Core;

namespace ScoreSystem 
{
    public class Score
    {
        private TextUploader textUploader;
        public Score(TextUploader textUploader)
        {
            this.textUploader = textUploader;
        }
        private int playerScore;
        public int PlayerScore
        {
            get => playerScore;
            set
            {
                playerScore = value;
                textUploader.m_action?.Invoke();
            }
        }
    }
}