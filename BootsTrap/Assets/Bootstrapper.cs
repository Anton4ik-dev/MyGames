using UnityEngine;
using ScoreSystem;

namespace Core
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private ClicksChecker clickChecker;
        [SerializeField] private QuitGame quitGame;
        [SerializeField] private TextUploader textUploader;
        private Game game;
        private Score score;
        private void Awake()
        {
            score = new Score(textUploader);
            clickChecker.Score = score;
            textUploader.Score = score;
            game = new Game(score);
            quitGame.Game = game;
        }
    }
}