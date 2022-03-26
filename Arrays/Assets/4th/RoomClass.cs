using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomClass : MonoBehaviour
{
    public int roomNumber = 0;
    public string civilianName = " ";
    public bool areAnimals = true;

    private void Start()
    {
        transform.GetChild(0).GetComponent<InputField>().text = "1";
        transform.GetChild(1).GetComponent<InputField>().text = "Name";
    }

    private void Update()
    {   
        roomNumber = int.Parse(transform.GetChild(0).GetComponent<InputField>().text);
        civilianName = transform.GetChild(1).GetComponent<InputField>().text;
        areAnimals = transform.GetChild(2).GetComponent<Toggle>().isOn;
    }
}
