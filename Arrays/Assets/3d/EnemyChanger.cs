using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyChanger : MonoBehaviour
{
    public Transform allEnemies;
    private List<EnemyScript> enemyArr = new List<EnemyScript>();
    private GameObject fieldForHealth;
    private void Start()
    {
        for (int i = 0; i < allEnemies.childCount; i++)
        {
            enemyArr.Add(allEnemies.GetChild(i).GetComponent<EnemyScript>());
        }
    }

    public void TurnOnUnitsByHealth()
    {
        int n = int.Parse(transform.GetChild(0).GetChild(1).GetComponent<Text>().text);
        for (int i = 0; i < allEnemies.childCount; i++)
        {
            if (n >= allEnemies.GetChild(i).GetComponent<EnemyScript>().health)
            {
                allEnemies.GetChild(i).gameObject.SetActive(false);
            }
        }
    }
    public void TurnOnUnitsByLvl()
    {
        int n = int.Parse(transform.GetChild(1).GetChild(1).GetComponent<Text>().text);
        for (int i = 0; i < allEnemies.childCount; i++)
        {
            if (n != allEnemies.GetChild(i).GetComponent<EnemyScript>().lvl)
            {
                allEnemies.GetChild(i).gameObject.SetActive(false);
            }
        }
    }

    public void Return()
    {
        for (int i = 0; i < allEnemies.childCount; i++)
        {
            allEnemies.GetChild(i).gameObject.SetActive(true);
            allEnemies.GetChild(i).GetChild(0).GetChild(0).GetComponent<Text>().text = allEnemies.GetChild(i).GetComponent<EnemyScript>().enemyNameSave;
            allEnemies.GetChild(i).GetChild(0).GetChild(1).GetComponent<Text>().text = allEnemies.GetChild(i).GetComponent<EnemyScript>().healthSave.ToString();
            allEnemies.GetChild(i).GetChild(0).GetChild(2).GetComponent<Text>().text = allEnemies.GetChild(i).GetComponent<EnemyScript>().lvlSave.ToString();
        }
    }
    public void Boss()
    {
        string n = transform.GetChild(2).GetChild(1).GetComponent<Text>().text;
        for (int i = 0; i < allEnemies.childCount; i++)
        {
            if (n == allEnemies.GetChild(i).GetComponent<EnemyScript>().enemyName)
            {
                allEnemies.GetChild(i).GetChild(0).GetChild(0).GetComponent<Text>().text = "Boss";
                allEnemies.GetChild(i).GetChild(0).GetChild(1).GetComponent<Text>().text = (allEnemies.GetChild(i).GetComponent<EnemyScript>().healthSave * 3).ToString();
                allEnemies.GetChild(i).GetChild(0).GetChild(2).GetComponent<Text>().text = (allEnemies.GetChild(i).GetComponent<EnemyScript>().lvlSave + 1).ToString();
            }
        }
    }
}
