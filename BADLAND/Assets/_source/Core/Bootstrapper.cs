using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
using Spawns;
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

        private LevelLoader _levelLoader;
        private SaveAndLoadService _saveAndLoadService;

        private Spawner _spawner;
        private Game _game;


        private void Awake()
        {
            _playerModel = new PlayerModel();
            _inputChecker.Constructor(_playerModel);

            _spawner = new Spawner();
            _saveAndLoadService = new SaveAndLoadService();
            _levelLoader = new LevelLoader(_levelParts, _finishPart, _spawner, _saveAndLoadService);
            _levelLoader.LoadLevel();

            _game = new Game(_playerPrefab, _spawner, _playerCamera, _playerModel, _saveAndLoadService);
        }
    }
}