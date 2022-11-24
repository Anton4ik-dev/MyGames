using TMPro;
using UnityEngine;

namespace StateSystem.PlayerStates
{
    public class InvinsibleState : AStatePlayer
    {
        private SpriteRenderer _playerSprite;
        private Color _spriteColor;
        private const float ALPHA_SCALER = 2f;
        private float _alpha;
        private bool _isTransparent;
        public InvinsibleState(PlayerStateMachine owner, TextMeshProUGUI stateText, SpriteRenderer playerSprite) : base(owner, stateText)
        {
            _playerSprite = playerSprite;
            _alpha = playerSprite.color.a;
            _spriteColor = new Color(_playerSprite.color.r, _playerSprite.color.g, _playerSprite.color.b, _alpha);
        }

        public override void Update()
        {
            if (Input.GetButtonDown(FIRE_AXIS))
            {
                if (_isTransparent)
                    _alpha *= ALPHA_SCALER;
                else
                    _alpha /= ALPHA_SCALER;

                _isTransparent = !_isTransparent;
                _spriteColor.a = _alpha;
                _playerSprite.color = _spriteColor;
            }
        }
    }
}