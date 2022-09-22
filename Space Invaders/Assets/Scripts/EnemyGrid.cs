using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyGrid : MonoBehaviour
{
    [SerializeField] private float _timeForDown;
    [SerializeField] private float _distance;
    [SerializeField] private Transform _winPanel;
    public Transform losePanel;
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private GameObject _enemy;
    private int _score;
    private float _timeSaver;
    private int enemyCount;

    private void Start()
    {
        enemyCount = transform.childCount;
        _timeSaver = _timeForDown;
        for (int i = 0; i < transform.childCount; i++)
        {
            Instantiate(_enemy, transform.GetChild(i).position, Quaternion.identity, transform.GetChild(i));
        }
    }

    private void Update()
    {
        _timeForDown -= Time.deltaTime;
        if (_timeForDown <= 0 && !CanvasScript.isPaused)
        {
            _timeForDown = _timeSaver;
            transform.position = new Vector2(transform.position.x, transform.position.y - _distance);
        }
    }
    public void EnemyDies(int howMuchToGive, GameObject enemyGameObject)
    {
        _score += howMuchToGive;
        _scoreText.text = $"Score : {_score}";
        Destroy(enemyGameObject);
        enemyCount--;
        if (enemyCount == 0)
        {
            CanvasScript.isPaused = true;
            _winPanel.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = _scoreText.text;
            _winPanel.gameObject.SetActive(true);
        }
    }
}