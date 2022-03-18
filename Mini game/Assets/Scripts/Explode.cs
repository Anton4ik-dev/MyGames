using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    private float explosionTimer;
    private CircleCollider2D explosionCollider;
    private Camera cam;
    private bool explode;

    [SerializeField] private float explosionForce;
    [SerializeField] private float explosionRadious;
    [SerializeField] private PointEffector2D explosion;
    [SerializeField] private float explosionTime;
    [SerializeField] private LayerMask explosionMask;

    private void Start()
    {
        explode = false;
        cam = GetComponent<Camera>();
        explosionCollider = explosion.GetComponent<CircleCollider2D>();
    }

    void Update()
    {
        if (explosionTimer > 0)
            explosionTimer -= Time.deltaTime;
        else if (explosionTimer <= 0)
            explode = false;

        if(Input.GetButtonDown("Fire1"))
        {
            Vector3 explosionCenter = cam.ScreenToWorldPoint(Input.mousePosition);
            explosionCenter.z = 0;

            explosion.transform.position = explosionCenter;
            explosion.forceMagnitude = explosionForce;
            explosionCollider.radius = explosionRadious;
            explosion.colliderMask = explosionMask;

            explosionTimer = explosionTime;

            explode = true;
        }

        explosion.gameObject.SetActive(explode);
    }
}
