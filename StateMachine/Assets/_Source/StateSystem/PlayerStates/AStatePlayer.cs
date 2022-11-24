using TMPro;

namespace StateSystem.PlayerStates
{
    public abstract class AStatePlayer
    {
        protected PlayerStateMachine _owner;
        protected TextMeshProUGUI _stateText;
        protected const string FIRE_AXIS = "Fire1";
        protected AStatePlayer(PlayerStateMachine owner, TextMeshProUGUI stateText)
        {
            _owner = owner;
            _stateText = stateText;
        }

        public void Enter()
        {
            _stateText.text = GetType().Name;
        }
        public abstract void Update();
        public void Exit()
        {
            _stateText.text = "";
        }
    }
}