using System.Collections.Generic;

namespace StateSystem.PlayerStates
{
    public class PlayerStateMachine
    {
        public Dictionary<int, AStatePlayer> states;
        private AStatePlayer _activeState;
        private int _activeStateNumber;

        public void SetStates(StateInitializer stateInitializer)
        {
            states = stateInitializer.playerStates;
            EnterNewState();
        }

        public void ChangeState()
        {
            ExitOldState();
            EnterNewState();
        }

        public void Update()
        {
            _activeState.Update();
        }

        private void ExitOldState()
        {
            _activeState.Exit();
            if (++_activeStateNumber == states.Count)
                _activeStateNumber = 0;
        }

        private void EnterNewState()
        {
            _activeState = states[_activeStateNumber];
            _activeState.Enter();
        }
    }
}