using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
using Spawns;
using Collision;
using SaveAndLoad;
using System;
using UnityEngine.SceneManagement;

namespace Core
{
    public class Game
    {
        public static Action<bool> OnEnd;
        private GameObject _player;
        private PlayerCamera _playerCamera;
        private PlayerModel _playerModel;
        private PlayerController _playerController;
        private PlayerView _playerView;
        private CollisionDetector _collisionDetector;
        private SaveAndLoadService _saveAndLoadService;
        private Spawner _spawner;
        private GameObject _playerPrefab;
        private CollisionService _collisionService;
        public Game(GameObject playerPrefab, Spawner spawner, PlayerCamera playerCamera, PlayerModel playerModel, SaveAndLoadService saveAndLoadService)
        {
            _playerPrefab = playerPrefab;
            _spawner = spawner;
            _playerCamera = playerCamera;

            _playerModel = playerModel;

            _saveAndLoadService = saveAndLoadService;

            StartGame();
        }
        private void StartGame()
        {
            _player = _spawner.SpawnPlayer(_playerPrefab);
            _playerView = _player.GetComponent<PlayerView>();
            _playerController = new PlayerController(_playerModel, _playerView);

            _collisionDetector = _player.GetComponent<CollisionDetector>();
            _collisionService = new CollisionService(_collisionDetector.Layers, _playerView);
            _collisionDetector.Constructor(_collisionService);

            _playerCamera.Constructor(_player);

            OnEnd += EndGame;
        }
        private void EndGame(bool isAlive)
        {
            _playerController.Expose();
            if (isAlive)
            {
                _saveAndLoadService.SaveAlive();
            } else
            {
                _saveAndLoadService.SaveDeath();
            }
            SceneManager.LoadScene(0);
        }
    }
}