using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerMovement
{
	public static void MoveForward(Rigidbody rb, float _speed)
	{
		rb.MovePosition(rb.transform.position + rb.transform.forward * Time.fixedDeltaTime * _speed);
	}
	public static void MoveBack(Rigidbody rb, float _speed)
	{
		rb.MovePosition(rb.transform.position + (-rb.transform.forward) * Time.fixedDeltaTime * _speed);
	}

	public static void Rotate(Rigidbody rb, float _rotationSpeed)
	{
		Vector3 rot = new Vector3(0f, Input.GetAxis("Horizontal") * _rotationSpeed, 0f);
		Quaternion delatRot = Quaternion.Euler(rot * Time.fixedDeltaTime);
		rb.MoveRotation(rb.rotation * delatRot);
	}

	public static void Jump(Rigidbody rb, float _jumpForce)
	{
		rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
	}
}