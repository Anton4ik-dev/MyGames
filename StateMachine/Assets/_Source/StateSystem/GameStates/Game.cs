using Player;
using UnityEngine;

namespace StateSystem.GameStates
{
    public class Game : AStateGame
    {
        private PlayerInput _playerInput;
        public Game(GameStateMachine owner, PlayerInput playerInput) : base(owner)
        {
            _playerInput = playerInput;
        }

        public override void Enter()
        {
            _playerInput.enabled = true;
        }
        public override void Update()
        {
            if (Input.GetKeyDown(SPACE_KEY))
            {
                _owner.ChangeState(typeof(Pause));
            }
            if (Input.GetKeyDown(ESC_KEY))
            {
                _owner.ChangeState(typeof(Final));
            }
        }
        public override void Exit()
        {
            _playerInput.enabled = false;
        }
    }
}