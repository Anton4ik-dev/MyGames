using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerFunctions
{
	static Vector3 stageDimensions = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
	public static void Move(GameObject player, float _speed, float axis)
	{
		Vector2 playerTransform = player.transform.position;
		float width = player.GetComponent<RectTransform>().rect.width / 2;
		if (playerTransform.x + axis * _speed <= -stageDimensions.x + width)
			player.transform.position = new Vector2(-stageDimensions.x + width, playerTransform.y);
		else if (playerTransform.x + axis * _speed >= stageDimensions.x - width)
			player.transform.position = new Vector2(stageDimensions.x - width, playerTransform.y);
		else
			player.transform.position = new Vector2(playerTransform.x + axis * _speed, playerTransform.y);
	}
	public static void Shoot(GameObject bullet, Transform shootPos)
	{
		GameObject go = MonoBehaviour.Instantiate(bullet, shootPos.position, Quaternion.identity);
	}
}