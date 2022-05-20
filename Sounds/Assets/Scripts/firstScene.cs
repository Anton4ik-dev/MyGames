using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firstScene : MonoBehaviour
{
    [SerializeField] private AudioSource clicckSound;
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
            Shoot();
    }

    void Shoot()
    {
        clicckSound.Play();
    }
}