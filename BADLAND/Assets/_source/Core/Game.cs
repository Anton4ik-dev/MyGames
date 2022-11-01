using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
using Collision;
using SaveAndLoad;
using System;
using UnityEngine.SceneManagement;

namespace Core
{
    public class Game
    {
        private GameObject _player;
        private PlayerCamera _playerCamera;
        private PlayerModel _playerModel;
        private PlayerController _playerController;
        private PlayerView _playerView;
        private InputChecker _inputChecker;
        private CollisionDetector _collisionDetector;
        private CollisionService _collisionService;
        private LevelLoader _levelLoader;
        private SaveAndLoadService _saveAndLoadService;
        public Game(GameObject player, PlayerCamera playerCamera, PlayerModel playerModel, PlayerView playerView, InputChecker inputChecker, CollisionDetector collisionDetector, LevelLoader levelLoader, SaveAndLoadService saveAndLoadService)
        {
            _player = player;
            _playerCamera = playerCamera;

            _playerModel = playerModel;
            _playerView = playerView;
            
            _inputChecker = inputChecker;

            _collisionDetector = collisionDetector;
            _collisionService = new CollisionService(_collisionDetector.Layers, _playerView, this);

            _levelLoader = levelLoader;
            _saveAndLoadService = saveAndLoadService;

            StartGame();
        }
        private void StartGame()
        {
            _levelLoader.LoadLevel();
            _playerCamera.Constructor(_player);
            _inputChecker.Constructor(_playerModel);
            _collisionDetector.Constructor(_collisionService);
            _playerController = new PlayerController(_playerModel, _playerView);
        }
        public void EndGame(bool isAlive)
        {
            if (isAlive)
            {
                _saveAndLoadService.SaveAlive();
            } else
            {
                _saveAndLoadService.SaveDeath();
            }
            _playerController.Expose();
            SceneManager.LoadScene(0);
        }
    }
}