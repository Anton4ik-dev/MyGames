using System.Collections;
using UnityEngine;

namespace Player
{
    public class InputChecker : MonoBehaviour
    {
        private PlayerModel _playerModel;
        private float x;
        private void Update()
        {
            x = Input.GetAxis("Horizontal");
            if (Input.GetButtonDown("Jump"))
            {
                _playerModel.MoveVertical();
            }
            if(x != 0)
            {
                _playerModel.MoveHorizontal(x);
            }
        }
        public void Constructor(PlayerModel playerModel)
        {
            _playerModel = playerModel;
        }
    }
}