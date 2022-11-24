using TMPro;
using UnityEngine;

namespace StateSystem.PlayerStates
{
    public class FinalState : AStatePlayer
    {
        private SpriteRenderer _playerSprite;
        private GameObject _redZone;
        public FinalState(PlayerStateMachine owner, TextMeshProUGUI stateText, SpriteRenderer playerSprite, GameObject redZone) : base(owner, stateText)
        {
            _playerSprite = playerSprite;
            _redZone = redZone;
        }
        public void EnterFinal()
        {
            _playerSprite.color = Color.green;
            _redZone.SetActive(false);
        }
        public override void Update()
        {

        }
    }
}