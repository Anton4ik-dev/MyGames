
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 15f;
    public Rigidbody2D rb;

    private void FixedUpdate()
    {
        rb.velocity = transform.right * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.tag = "NotEnemy";
            collision.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        }
        if (collision.gameObject.CompareTag("uniqueEnemy"))
        {
            Destroy(collision.gameObject);
        }
        Destroy(gameObject);
    }

}