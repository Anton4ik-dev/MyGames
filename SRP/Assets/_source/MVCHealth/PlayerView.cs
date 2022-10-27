using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MVC
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _playerImage;
        [SerializeField] private Color _healthy;
        [SerializeField] private Color _badly;
        private Text _text;
        private Button _restartButton;
        public void Constructor(Text text, Button restartButton)
        {
            _text = text;
            _restartButton = restartButton;
        }

        public void ShowPlayerDeath()
        {
            _restartButton.gameObject.SetActive(true);
            _restartButton.onClick.AddListener(Restart);
        }
        public void UpdateHealthView(int health)
        {
            _text.text = health.ToString();
            if (health > 50)
                _playerImage.color = _healthy;
            else
                _playerImage.color = _badly;
        }
        
        private void Restart()
        {
            SceneManager.LoadScene(0);
        }
    }
}