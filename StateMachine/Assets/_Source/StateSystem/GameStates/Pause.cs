using UnityEngine;

namespace StateSystem.GameStates
{
    public class Pause : AStateGame
    {
        public Pause(GameStateMachine owner) : base(owner)
        {

        }

        public override void Enter()
        {
            Time.timeScale = 0;
        }
        public override void Update()
        {
            if (Input.GetKeyDown(SPACE_KEY))
            {
                _owner.ChangeState(typeof(Game));
            }
            if (Input.GetKeyDown(ESC_KEY))
            {
                _owner.ChangeState(typeof(Final));
            }
        }
        public override void Exit()
        {
            Time.timeScale = 1;
        }
    }
}