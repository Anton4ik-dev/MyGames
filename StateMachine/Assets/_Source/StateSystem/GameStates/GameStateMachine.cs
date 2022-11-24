using System;
using System.Collections.Generic;

namespace StateSystem.GameStates
{
    public class GameStateMachine
    {
        private Dictionary<Type, AStateGame> states;
        private AStateGame _activeState;

        public void SetStates(StateInitializer stateInitializer)
        {
            states = stateInitializer.gameStates;
        }

        public void ChangeState(Type type)
        {
            _activeState.Exit();
            StartState(type);
        }

        public void StartState(Type type)
        {
            _activeState = states[type];
            _activeState.Enter();
        }

        public void Update()
        {
            _activeState.Update();
        }
    }
}