using System.Collections;
using UnityEngine;

namespace Player
{
    public class PlayerCamera : MonoBehaviour
    {
        [SerializeField] private Transform _cameraTransform;
        private GameObject _player;
        private void Update()
        {
            _cameraTransform.position = new Vector3(_player.transform.position.x, 0, -10);
        }
        public void Constructor(GameObject player)
        {
            _player = player;
        }
    }
}