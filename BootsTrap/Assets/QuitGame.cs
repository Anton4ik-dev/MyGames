using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class QuitGame : MonoBehaviour
    {
        private Game game;
        public Game Game
        {
            get => game;
            set
            {
                game = value;
            }
        }
        void Update()
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                game.QuitGame();
            }
        }
    }
}