using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RightSpawnMobs : MonoBehaviour
{
    public Transform spawnPos;
    public GameObject mob;
    public float remainTime = 3f;
    public static Transform end;
    public static Transform game;
    private void Start()
    {
        end = GameObject.FindWithTag("Dead").GetComponent<Transform>();
        end.gameObject.SetActive(false);
        game = GameObject.FindWithTag("Game").GetComponent<Transform>();
    }
    private void Update()
    {
        remainTime -= Time.deltaTime;
        if (remainTime < 0)
        {
            Instantiate(mob, spawnPos);
            remainTime = 3f;
        }
    }
    public static void EndGame()
    {
        end.gameObject.SetActive(true);
        game.gameObject.SetActive(false);
    }
}
