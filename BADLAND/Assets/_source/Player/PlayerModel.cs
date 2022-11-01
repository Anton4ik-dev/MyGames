using System;
using System.Collections;
using UnityEngine;

namespace Player
{
    public class PlayerModel
    {
        private Vector2 _newVector;
        public Action<float> OnMoveHorizontal;
        public Action OnMoveVertical;

        public void MoveHorizontal(float x)
        {
            OnMoveHorizontal?.Invoke(x);
        }
        public void MoveVertical()
        {
            OnMoveVertical?.Invoke();
        }
    }
}