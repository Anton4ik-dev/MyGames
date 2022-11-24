using TMPro;
using UnityEngine;

namespace StateSystem.PlayerStates
{
    public class ShootState : AStatePlayer
    {
        private Transform _firePoint;
        private GameObject _bullet;
        public ShootState(PlayerStateMachine owner, TextMeshProUGUI stateText, Transform firePoint, GameObject bullet) : base(owner, stateText)
        {
            _firePoint = firePoint;
            _bullet = bullet;
        }

        public override void Update()
        {
            if (Input.GetButtonDown(FIRE_AXIS))
            {
                Object.Instantiate(_bullet, _firePoint.position, Quaternion.identity);
            }
        }
    }
}