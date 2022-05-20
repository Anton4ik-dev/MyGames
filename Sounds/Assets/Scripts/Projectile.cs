using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 15f;
    public Rigidbody rb;
    public AudioSource pau;

    private void Start()
    {
        pau.volume = CanvasSCR.sfxVolume;
    }
    private void FixedUpdate()
    {
        rb.velocity = transform.forward * speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        pau.Play();
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        gameObject.GetComponent<SphereCollider>().enabled = false;
        Destroy(gameObject, 2);
    }
}