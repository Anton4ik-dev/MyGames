using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
using Collision;
using SaveAndLoad;

namespace Core
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private GameObject _playerPrefab;
        [SerializeField] private PlayerCamera _playerCamera;
        [SerializeField] private InputChecker _inputChecker;
        [SerializeField] private List<GameObject> _levelParts;
        [SerializeField] private GameObject _finishPart;

        private PlayerModel _playerModel;
        private PlayerView _playerView;

        private CollisionDetector _collisionDetector;

        private LevelLoader _levelLoader;
        private SaveAndLoadService _saveAndLoadService;

        private Spawner _spawner;
        private GameObject _player;
        private Game _game;
        
        private void Awake()
        {
            _spawner = new Spawner();
            _player = _spawner.SpawnPlayer(_playerPrefab);

            _playerModel = new PlayerModel();
            _playerView = _player.GetComponent<PlayerView>();

            _collisionDetector = _player.GetComponent<CollisionDetector>();

            _saveAndLoadService = new SaveAndLoadService();
            _levelLoader = new LevelLoader(_levelParts, _finishPart, _spawner, _saveAndLoadService);

            _game = new Game(_player, _playerCamera, _playerModel, _playerView, _inputChecker, _collisionDetector, _levelLoader, _saveAndLoadService);
        }
    }
}