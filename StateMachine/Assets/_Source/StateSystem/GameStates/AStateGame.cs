using UnityEngine;

namespace StateSystem.GameStates
{
    public abstract class AStateGame
    {
        protected GameStateMachine _owner;
        protected const KeyCode ESC_KEY = KeyCode.Escape;
        protected const KeyCode SPACE_KEY = KeyCode.Space;
        protected AStateGame(GameStateMachine owner)
        {
            _owner = owner;
        }

        public virtual void Enter() { }
        public virtual void Update() { }
        public virtual void Exit() { }
    }
}