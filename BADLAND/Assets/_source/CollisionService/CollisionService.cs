using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
using Core;

namespace Collision
{
    public class CollisionService
    {
        private List<int> _layers;
        private PlayerView _playerView;
        private Game _game;
        public CollisionService(List<int> layers, PlayerView playerView, Game game)
        {
            _layers = layers;
            _playerView = playerView;
            _game = game;
        }
        public void CheckEnteredCollision(Collision2D collision)
        {
            if (collision.gameObject.layer == _layers[0])
            {
                _playerView.IsGrounded = true;
            } else if(collision.gameObject.layer == _layers[1])
            {
                //dropper
            } else if(collision.gameObject.layer == _layers[2])
            {
                _game.EndGame(false);
            } else if (collision.gameObject.layer == _layers[3])
            {
                _game.EndGame(true);
            } else if (collision.gameObject.layer == _layers[4])
            {
                _playerView.MakeLarger();
            } else if (collision.gameObject.layer == _layers[5])
            {
                _playerView.MakeSmaller();
            }
        }
        public void CheckExitCollision(Collision2D collision)
        {
            if (collision.gameObject.layer == _layers[0])
            {
                _playerView.IsGrounded = false;
            }
        }
    }
}