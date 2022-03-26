using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    public string enemyNameSave;
    public int healthSave;
    public int lvlSave;


    public string enemyName;
    public int health;
    public int lvl;

    private void Start()
    {
        healthSave = int.Parse(transform.GetChild(0).GetChild(1).GetComponent<Text>().text);
        lvlSave = int.Parse(transform.GetChild(0).GetChild(2).GetComponent<Text>().text);
        enemyNameSave = transform.GetChild(0).GetChild(0).GetComponent<Text>().text;
    }

    private void Update()
    {
        health = int.Parse(transform.GetChild(0).GetChild(1).GetComponent<Text>().text);
        lvl = int.Parse(transform.GetChild(0).GetChild(2).GetComponent<Text>().text);
        enemyName = transform.GetChild(0).GetChild(0).GetComponent<Text>().text;
    }
}
