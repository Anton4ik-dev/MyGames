using StateSystem.PlayerStates;
using UnityEngine;

namespace StateSystem.GameStates
{
    public class Final : AStateGame
    {
        private FinalPlayerState _finalState;
        public Final(GameStateMachine owner, FinalPlayerState finalState) : base(owner)
        {
            _finalState = finalState;
        }

        public override void Enter()
        {
            Time.timeScale = 0;
            _finalState.EnterFinal();
        }
    }
}