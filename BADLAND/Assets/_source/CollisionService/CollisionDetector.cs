using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Collision
{
    public class CollisionDetector : MonoBehaviour
    {
        [SerializeField] private List<int> _layers;
        public List<int> Layers {
            get
            {
                return _layers;
            }
            private set
            {

            }
        }
        private CollisionService _collisionService;
        private void OnCollisionEnter2D(Collision2D collision)
        {
            _collisionService.CheckEnteredCollision(collision);
        }
        private void OnCollisionStay2D(Collision2D collision)
        {
            _collisionService.Dropper(collision);
        }
        private void OnCollisionExit2D(Collision2D collision)
        {
            _collisionService.CheckExitCollision(collision);
        }
        public void Constructor(CollisionService collisionService)
        {
            _collisionService = collisionService;
        }
    }
}