using StateSystem.PlayerStates;
using UnityEngine;

namespace Player
{
    public class PlayerInput : MonoBehaviour
    {
        [SerializeField] private KeyCode enter;
        [SerializeField] private PlayerMovement playerMovement;

        private PlayerStateMachine _playerStateMachine;
        private float moveHorizontal;
        private float moveVertical;

        private const string HORIZONTAL_AXIS = "Horizontal";
        private const string VERTICAL_AXIS = "Vertical";

        public void Construct(PlayerStateMachine playerStateMachine)
        {
            _playerStateMachine = playerStateMachine;
        }

        private void Update()
        {
            moveHorizontal = Input.GetAxis(HORIZONTAL_AXIS);
            moveVertical = Input.GetAxis(VERTICAL_AXIS);

            if (moveHorizontal != 0 || moveVertical != 0)
                playerMovement.MovePlayer(moveHorizontal, moveVertical);

            if (Input.GetKeyDown(enter))
                _playerStateMachine.ChangeState();

            _playerStateMachine.Update();
        }
    }
}