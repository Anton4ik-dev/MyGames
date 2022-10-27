using System;

namespace MVC
{
    public class PlayerModel
    {
        private int _health;
        private int _maxHealth = 100;
        public Action<int> OnHealthChange;
        public Action OnPlayerDeath;
        public PlayerModel()
        {
            _health = _maxHealth;
        }

        public void ChangeHealth(int deltaHealth)
        {
            _health += deltaHealth;
            OnHealthChange?.Invoke(_health);
            if (_health <= 0)
                OnPlayerDeath?.Invoke();
        }
    }
}