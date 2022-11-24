using StateSystem.PlayerStates;
using UnityEngine;

namespace StateSystem.GameStates
{
    public class Final : AStateGame
    {
        private FinalState _finalState;
        public Final(GameStateMachine owner, FinalState finalState) : base(owner)
        {
            _finalState = finalState;
        }

        public override void Enter()
        {
            Time.timeScale = 0;
            _finalState.EnterFinal();
        }
        public override void Update()
        {

        }
        public override void Exit()
        {

        }
    }
}