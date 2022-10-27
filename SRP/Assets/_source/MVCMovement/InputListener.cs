using UnityEngine;

namespace MVCMovement
{
    public class InputListener : MonoBehaviour
    {
        private PlayerMovementModel _playerMovementModel;
        private void Update()
        {
            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");
            _playerMovementModel.ChangeVector(x, y);
        }
        public void Constructor(PlayerMovementModel playerMovementModel)
        {
            _playerMovementModel = playerMovementModel;
        }
    }
}
