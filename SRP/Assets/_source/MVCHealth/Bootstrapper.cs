using UnityEngine;
using UnityEngine.UI;
using MVCMovement;

namespace MVC
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private GameObject _playerPrefab;
        [SerializeField] private GameObject _enemyPrefab;
        [SerializeField] private Transform _enemySpawn;
        [SerializeField] private Text _text;
        [SerializeField] private Button _restartButton;
        [SerializeField] private InputListener _inputListener;

        private PlayerView _playerView;
        private PlayerMovementView _playerMovementView;
        private PlayerController _playerController;
        private PlayerModel _playerModel;
        private PlayerMovementController _playerMovementController;
        private PlayerMovementModel _playerMovementModel;

        private void Awake()
        {
            _playerModel = new PlayerModel();
            _playerMovementModel = new PlayerMovementModel();

            GameObject player = Instantiate(_playerPrefab);
            GameObject enemy = Instantiate(_enemyPrefab, _enemySpawn.position, Quaternion.identity);
            enemy.GetComponent<Enemy>().Constructor(_playerModel);

            _playerView = player.GetComponent<PlayerView>();
            _playerView.Constructor(_text, _restartButton);
            _playerMovementView = player.GetComponent<PlayerMovementView>();

            _inputListener.Constructor(_playerMovementModel);
                      
            _playerMovementController = new PlayerMovementController(_playerMovementModel, _playerMovementView);
            _playerController = new PlayerController(_playerModel, _playerView, _playerMovementController);
        }
    }
}