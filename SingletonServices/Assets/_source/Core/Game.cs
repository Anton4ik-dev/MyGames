using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Core
{
    public class Game
    {
        private MainTimer _mainTimer;
        private GameObject _losePanel;
        private Button _button;
        public Game(MainTimer mainTimer, GameObject losePanel, Button button)
        {
            _losePanel = losePanel;
            _mainTimer = mainTimer;
            _button = button;
            Start();
        }
        private void Start()
        {
            _mainTimer.StartTimer();
            _button.onClick.AddListener(() => RestartGame());
        }
        public void Quit()
        {
            _mainTimer.StopTimer();
            _losePanel.SetActive(true);
        }
        private void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}