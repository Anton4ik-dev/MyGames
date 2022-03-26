using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomsChanger : MonoBehaviour
{
    public GameObject roomPrefab;
    private List<RoomClass> roomArr = new List<RoomClass>();
    
    public void ChangeRoomCount()
    {
        roomArr.Clear();
        for (int i = 0; i < transform.GetChild(1).childCount; i++)
        {
            roomArr.Add(transform.GetChild(1).GetChild(i).GetComponent<RoomClass>());
        }

        for (int i = 0; i < transform.GetChild(1).childCount; i++)
        {
            Destroy(transform.GetChild(1).GetChild(i).gameObject);
        }

        for (int i = 0; i < int.Parse(transform.GetChild(0).GetChild(0).GetChild(1).GetComponent<Text>().text); i++)
        {
            Instantiate(roomPrefab, transform.GetChild(1).transform);
        }
    }

    public void Methods()
    {
        roomArr.Clear();
        for (int i = 0; i < transform.GetChild(1).childCount; i++)
        {
            roomArr.Add(transform.GetChild(1).GetChild(i).GetComponent<RoomClass>());
        }
        int cntAnimals = 0;
        int cntSmits = 0;
        int cntRooms = 0;
        int min = int.Parse(transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<InputField>().text);
        int minPos = 0;
        int lastRoomWithAnimal = 0;
        for (int i = 0; i < transform.GetChild(1).childCount; i++)
        {
            if (transform.GetChild(1).GetChild(i).GetComponent<RoomClass>().areAnimals)
            {
                lastRoomWithAnimal = i;
                cntAnimals++;
            }
            if (transform.GetChild(1).GetChild(i).GetComponent<RoomClass>().civilianName == "Смит")
                cntSmits++;
            if (transform.GetChild(1).GetChild(i).GetComponent<RoomClass>().roomNumber < 10 && transform.GetChild(1).GetChild(i).GetComponent<RoomClass>().roomNumber > -1)
                cntRooms++;
            if(int.Parse(transform.GetChild(1).GetChild(i).GetChild(0).GetComponent<InputField>().text) <= min)
            {
                min = int.Parse(transform.GetChild(1).GetChild(i).GetChild(0).GetComponent<InputField>().text);
                minPos = i;
            }
        }

        Debug.Log($"Кол-во жильцов с животными {cntAnimals}");
        Debug.Log($"Кол-во жильцов с именем Смит {cntSmits}");
        Debug.Log($"Кол-во жильцов с однозначными номерами {cntRooms}");

        for (int i = 0, j = transform.GetChild(1).childCount; i < transform.GetChild(1).childCount / 2; i++)
        {
            string saver = transform.GetChild(1).GetChild(i).GetChild(1).GetComponent<InputField>().text;
            transform.GetChild(1).GetChild(i).GetChild(1).GetComponent<InputField>().text = transform.GetChild(1).GetChild(j - 1 - i).GetChild(1).GetComponent<InputField>().text;
            transform.GetChild(1).GetChild(j - 1 - i).GetChild(1).GetComponent<InputField>().text = saver;
        }

        for (int i = 0; i < transform.GetChild(1).childCount; i++)
        {
            if (transform.GetChild(1).GetChild(i).GetComponent<RoomClass>().roomNumber % 3 == 0)
                Destroy(transform.GetChild(1).GetChild(i).gameObject);
        }

        string saver1 = transform.GetChild(1).GetChild(minPos).GetChild(1).GetComponent<InputField>().text;
        transform.GetChild(1).GetChild(minPos).GetChild(1).GetComponent<InputField>().text = transform.GetChild(1).GetChild(lastRoomWithAnimal).GetChild(1).GetComponent<InputField>().text;
        transform.GetChild(1).GetChild(lastRoomWithAnimal).GetChild(1).GetComponent<InputField>().text = saver1;

        string saver2 = transform.GetChild(1).GetChild(minPos).GetChild(0).GetComponent<InputField>().text;
        transform.GetChild(1).GetChild(minPos).GetChild(0).GetComponent<InputField>().text = transform.GetChild(1).GetChild(lastRoomWithAnimal).GetChild(0).GetComponent<InputField>().text;
        transform.GetChild(1).GetChild(lastRoomWithAnimal).GetChild(0).GetComponent<InputField>().text = saver2;

        bool saver3 = transform.GetChild(1).GetChild(minPos).GetChild(2).GetComponent<Toggle>().isOn;
        transform.GetChild(1).GetChild(minPos).GetChild(2).GetComponent<Toggle>().isOn = transform.GetChild(1).GetChild(lastRoomWithAnimal).GetChild(2).GetComponent<Toggle>().isOn;
        transform.GetChild(1).GetChild(lastRoomWithAnimal).GetChild(2).GetComponent<Toggle>().isOn = saver3;
    }
}