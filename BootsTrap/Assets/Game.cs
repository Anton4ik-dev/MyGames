using ScoreSystem;

namespace Core
{
    public class Game
    {
        private const int PLAYER_SCORE = 5;
        private Score score;
        public Game(Score score)
        {
            this.score = score;
            StartGame();
        }
        private void StartGame()
        {
            score.PlayerScore = PLAYER_SCORE;
        }
        public void QuitGame()
        {
            score.PlayerScore = 0;
        }
    }
}