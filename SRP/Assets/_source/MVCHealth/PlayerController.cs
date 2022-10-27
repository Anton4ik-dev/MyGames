using MVCMovement;

namespace MVC
{
    public class PlayerController
    {
        private PlayerModel _playerModel;
        private PlayerView _playerView;
        private PlayerMovementController _playerMovementController;

        public PlayerController(PlayerModel playerModel, PlayerView playerView, PlayerMovementController playerMovementController)
        {
            _playerModel = playerModel;
            _playerView = playerView;
            _playerMovementController = playerMovementController;
            Bind();
            _playerModel.ChangeHealth(0);
        }

        private void Bind()
        {
            _playerModel.OnHealthChange += OnHealthChanged;
            _playerModel.OnPlayerDeath += OnDeath;
        }
        private void Expose()
        {
            _playerModel.OnHealthChange -= OnHealthChanged;
            _playerModel.OnPlayerDeath -= OnDeath;
        }
        private void OnHealthChanged(int health) => _playerView.UpdateHealthView(health);
        private void OnDeath()
        {
             _playerView.ShowPlayerDeath();
            Expose();
            _playerMovementController.Expose();
        }
    }
}