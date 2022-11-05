using System.Collections;
using UnityEngine;

namespace Player
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private Transform _transform;
        [SerializeField] private float _horizontalSpeed;
        [SerializeField] private float _verticalSpeed;
        [SerializeField] private float _sizeChanger;
        private bool _isGrounded = false;
        public bool IsGrounded
        { 
            get
            {
                return _isGrounded;
            }
            set
            {
                _isGrounded = value;
            }
        }

        public void UpdateHorizontal(float x)
        {
            if(_isGrounded == false)
                _rb.velocity = new Vector2(x * _horizontalSpeed, _rb.velocity.y);
        }
        public void UpdateVertical()
        {
            _rb.velocity = new Vector2(_rb.velocity.x, Vector2.up.y * _verticalSpeed);
            CorrectRotation();
        }
        public void MakeLarger()
        {
            _transform.localScale = new Vector3(_transform.localScale.x * _sizeChanger, _transform.localScale.y * _sizeChanger);
            _rb.mass *= _sizeChanger;
        }
        public void MakeSmaller()
        {
            _transform.localScale = new Vector3(_transform.localScale.x / _sizeChanger, _transform.localScale.y / _sizeChanger);
            _rb.mass /= _sizeChanger;
        }
        private void CorrectRotation()
        {
            _transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
            _rb.MoveRotation(_transform.rotation);
        }
    }
}