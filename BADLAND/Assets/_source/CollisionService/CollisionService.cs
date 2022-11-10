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
        public CollisionService(List<int> layers, PlayerView playerView)
        {
            _layers = layers;
            _playerView = playerView;
        }
        public void CheckEnteredCollision(Collision2D collision)
        {
            if (collision.gameObject.layer == _layers[0])
            {
                _playerView.IsGrounded = true;
            } else if(collision.gameObject.layer == _layers[1])
            {
                collision.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            } else if(collision.gameObject.layer == _layers[2])
            {
                Game.OnEnd?.Invoke(false);
            } else if (collision.gameObject.layer == _layers[3])
            {
                Game.OnEnd?.Invoke(true);
            } else if (collision.gameObject.layer == _layers[4])
            {
                _playerView.MakeLarger();
                collision.gameObject.SetActive(false);
            } else if (collision.gameObject.layer == _layers[5])
            {
                _playerView.MakeSmaller();
                collision.gameObject.SetActive(false);
            }
        }
        public void CheckExitCollision(Collision2D collision)
        {
            if (collision.gameObject.layer == _layers[0])
            {
                _playerView.IsGrounded = false;
            }
        }
        public void Dropper(Collision2D collision)
        {
            if (collision.gameObject.layer == _layers[1])
            {
                if (_playerView.IsGrounded)
                {
                    Game.OnEnd?.Invoke(false);
                }
            }
        }
    }
}