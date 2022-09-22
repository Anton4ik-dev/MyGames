using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPMPlayerMove : MonoBehaviour
{
	[SerializeField] private float _speed;
	[SerializeField] private float _rotationSpeed;
	[SerializeField] private float _jumpForce;

	private Rigidbody rb;
	void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

    private void Update()
    {
		Move();
		Rotate();
		Jump();
	}

    private void Move()
    {
		if (Input.GetAxis("Vertical") > 0)
        {
			rb.MovePosition(transform.position + transform.forward * Time.fixedDeltaTime * _speed);
		} else if(Input.GetAxis("Vertical") < 0)
        {
			rb.MovePosition(transform.position + (-transform.forward) * Time.fixedDeltaTime * _speed);
		}
    }

	private void Rotate()
	{
		if (Input.GetAxis("Horizontal") != 0)
        {
			Vector3 rot = new Vector3(0f, Input.GetAxis("Horizontal") * _rotationSpeed, 0f);
			Quaternion delatRot = Quaternion.Euler(rot * Time.fixedDeltaTime);
			rb.MoveRotation(rb.rotation * delatRot);
		}
	}

	private void Jump()
	{
		if(Input.GetButtonDown("Jump"))
			rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
	}
}
