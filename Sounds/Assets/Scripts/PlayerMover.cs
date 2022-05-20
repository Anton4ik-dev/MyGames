using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float Speed;
    private Rigidbody rb;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private AudioSource clicckSound;
    [SerializeField] private AudioSource mainSound;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        Vector2 newVelo = transform.right * moveX * Speed;
        newVelo.y = rb.velocity.y;
        rb.velocity = newVelo;
        if (Input.GetButtonDown("Fire1"))
            Shoot();
        clicckSound.volume = CanvasSCR.sfxVolume;
        mainSound.volume = CanvasSCR.mainVolume;
    }

    void Shoot()
    {
        clicckSound.Play();
        Instantiate(bulletPrefab, firePoint.position, Quaternion.Euler(new Vector3(0f, 0f, 0f)));
    }
}