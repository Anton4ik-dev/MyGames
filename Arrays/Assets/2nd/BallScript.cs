using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    [SerializeField] private Material TrueMaterial;
    [SerializeField] private float porog;

    private float speed;
    private Rigidbody rb;
    private float timer;
    private bool isBlue = false;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Mathf.Abs(rb.velocity.y) < porog)
        {
            TrueMaterial.color = Color.blue;
            timer += Time.deltaTime;
            isBlue = true;
        }

        if(isBlue == true && Mathf.Abs(rb.velocity.y) >= porog)
        {
            Debug.Log(timer);
            timer = 0;
            TrueMaterial.color = Color.yellow;
            isBlue = false;
        }
    }
}