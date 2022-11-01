using System.Collections;
using UnityEngine;

namespace Player
{
    public class PlayerController
    {
        private PlayerModel _playerModel;
        private PlayerView _playerView;
        public PlayerController(PlayerModel playerModel, PlayerView playerView)
        {
            _playerModel = playerModel;
            _playerView = playerView;
            Bind();
        }
        private void Bind()
        {
            _playerModel.OnMoveHorizontal += OnMoveHorizontal;
            _playerModel.OnMoveVertical += OnMoveVertical;
        }
        public void Expose()
        {
            _playerModel.OnMoveHorizontal -= OnMoveHorizontal;
            _playerModel.OnMoveVertical -= OnMoveVertical;
        }

        private void OnMoveHorizontal(float x) => _playerView.UpdateHorizontal(x);
        private void OnMoveVertical() => _playerView.UpdateVertical();
    }
}