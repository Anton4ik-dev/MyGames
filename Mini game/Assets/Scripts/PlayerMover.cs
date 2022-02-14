using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMover : MonoBehaviour
{
    public Image[] hearts;
    private int health;

    public float Speed, JumpForce;

    private Rigidbody2D rb;
    public LayerMask groundLayer;
    private Transform groundChecker;

    [HideInInspector] public bool isFacingRight = true;
    public float fireRate = 0.2f;
    public Transform firePoint;
    public Transform firePoint2;
    public GameObject bulletPrefab;

    float timeUntilFire;
    PlayerMover pm;
    

    void Start()
    {
        health = hearts.Length;
        groundChecker = transform.GetChild(0);
        rb = GetComponent<Rigidbody2D>();
        pm = gameObject.GetComponent<PlayerMover>();
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");

        Vector2 newVelo = transform.right * moveX * Speed;
        newVelo.y = rb.velocity.y;
        rb.velocity = newVelo;
        RaycastHit2D grounded = Physics2D.Raycast(groundChecker.position, Vector2.down, 0.1f, groundLayer);
        if (Input.GetButtonDown("Jump") && grounded)
        {
            rb.AddForce(Vector3.up * JumpForce, ForceMode2D.Impulse);
        }

        if (rb.velocity.x > 0)
        {
            isFacingRight = true;
        }
        else if (rb.velocity.x < 0)
        {
            isFacingRight = false;
        }
        if (Input.GetButtonDown("Fire1") && timeUntilFire < Time.time)
        {
            Shoot();
            timeUntilFire = Time.time + fireRate;
        }
    }
    void Shoot()
    {
        float angle = pm.isFacingRight ? 0f : 180f;
        if (angle == 0f)
            Instantiate(bulletPrefab, firePoint.position, Quaternion.Euler(new Vector3(0f, 0f, angle)));
        else
            Instantiate(bulletPrefab, firePoint2.position, Quaternion.Euler(new Vector3(0f, 0f, angle)));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "uniqueEnemy")
        {
            health--;
            for (int i = health; i >= 0; i++)
            {
                if(i > 0)
                {
                    hearts[i].enabled = false;
                    break;
                }
                if(i==0)
                {
                    SceneManager.LoadScene(0);
                }
            }
        }
    }
}