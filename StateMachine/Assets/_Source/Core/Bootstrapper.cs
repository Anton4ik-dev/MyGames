using Player;
using StateSystem;
using StateSystem.GameStates;
using StateSystem.PlayerStates;
using TMPro;
using UnityEngine;

namespace Core
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private PlayerInput playerInput;
        [SerializeField] private TextMeshProUGUI stateText;
        [SerializeField] private Transform firePoint;
        [SerializeField] private GameObject bullet;
        [SerializeField] private GameObject redZone;
        [SerializeField] private SpriteRenderer playerSprite;

        private PlayerStateMachine _playerStateMachine;
        private GameStateMachine _gameStateMachine;
        private StateInitializer _stateInitializer;

        private void Awake()
        {
            _playerStateMachine = new PlayerStateMachine();
            _gameStateMachine = new GameStateMachine();
            playerInput.Construct(_playerStateMachine);

            _stateInitializer = new StateInitializer(_playerStateMachine, _gameStateMachine, stateText, firePoint, bullet, redZone, playerSprite, playerInput);

            _gameStateMachine.StartState(typeof(Game));
        }

        private void Update()
        {
            _gameStateMachine.Update();
        }
    }
}