using UnityEngine;

namespace MVCMovement
{
    public class PlayerMovementController
    {
        private PlayerMovementModel _playerMovementModel;
        private PlayerMovementView _playerMovementView;

        public PlayerMovementController(PlayerMovementModel playerMovementModel, PlayerMovementView playerMovementView)
        {
            _playerMovementModel = playerMovementModel;
            _playerMovementView = playerMovementView;
            Bind();
        }

        private void Bind()
        {
            _playerMovementModel.OnVectorChange += OnChangeVector;
        }
        public void Expose()
        {
            _playerMovementModel.OnVectorChange -= OnChangeVector;
        }
        private void OnChangeVector(Vector2 newVector) => _playerMovementView.UpdatePlayerView(newVector);
    }
}