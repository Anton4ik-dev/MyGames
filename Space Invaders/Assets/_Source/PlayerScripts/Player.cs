using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Invoker _invoker;
    private void Start()
    {
        _invoker = new Invoker(FindObjectOfType<Player>());
    }
    public float speed;
    public GameObject bullet;
    public Transform shootPos;
}
