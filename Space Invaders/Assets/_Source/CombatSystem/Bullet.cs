using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float _aliveTime;
    private void Update()
    {
        _aliveTime -= Time.deltaTime;
        rb.velocity = new Vector2(0, _speed);
        if(_aliveTime <= 0)
        {
            Destroy(gameObject);
        }
    }
}
