using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _hp;
    [SerializeField] private int _howMuchToGive;
    private EnemyGrid _enemyGrid;
    
    private void Start()
    {
        _enemyGrid = transform.parent.GetComponentInParent<EnemyGrid>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            _hp--;
            if (_hp == 0)
            {
                _enemyGrid.EnemyDies(_howMuchToGive, gameObject);
            }
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Lose"))
        {
            CanvasScript.isPaused = true;
            _enemyGrid.losePanel.gameObject.SetActive(true);
        }
    }
}