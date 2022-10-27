using System;
using UnityEngine;

namespace MVCMovement
{
    public class PlayerMovementModel
    {
        private Vector2 newVector;
        private float _speed = 5f;
        public Action<Vector2> OnVectorChange;

        public void ChangeVector(float xAxis, float yAxis)
        {
            newVector = new Vector2(xAxis * _speed, yAxis * _speed);
            OnVectorChange?.Invoke(newVector);
        }
    }
}