using TMPro;
using UnityEngine;

namespace StateSystem.PlayerStates
{
    public class FinalPlayerState : AStatePlayer
    {
        private SpriteRenderer _playerSprite;
        private GameObject _redZone;
        public FinalPlayerState(PlayerStateMachine owner, TextMeshProUGUI stateText, SpriteRenderer playerSprite, GameObject redZone) : base(owner, stateText)
        {
            _playerSprite = playerSprite;
            _redZone = redZone;
        }
        public void EnterFinal()
        {
            _playerSprite.color = Color.green;
            _redZone.SetActive(false);
        }
    }
}