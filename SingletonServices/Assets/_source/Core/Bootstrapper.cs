using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Core
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private MainTimer _mainTimer;
        [SerializeField] private Button _button;
        [SerializeField] private GameObject _losePanel;
        private Game _game;
        public Game Game => _game;
        private void Awake()
        {
            _game = new Game(_mainTimer, _losePanel, _button);
        }
    }
}