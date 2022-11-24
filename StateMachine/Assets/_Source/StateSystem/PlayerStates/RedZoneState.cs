using TMPro;
using UnityEngine;

namespace StateSystem.PlayerStates
{
    public class RedZoneState : AStatePlayer
    {
        private GameObject _redZone;
        public RedZoneState(PlayerStateMachine owner, TextMeshProUGUI stateText, GameObject redZone) : base(owner, stateText)
        {
            _redZone = redZone;
        }

        public override void Update()
        {
            if (Input.GetButtonDown(FIRE_AXIS))
            {
                _redZone.SetActive(!_redZone.activeSelf);
            }
        }
    }
}