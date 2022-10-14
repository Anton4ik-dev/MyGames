using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private InputField input;
    [SerializeField] private Dropdown dropdown;
    private Resources.Types type = Resources.Types.Gold;
    private int amount = 0;
    private void Start()
    {
        input.onValueChanged.AddListener(delegate { ChangeAmount(int.Parse(input.text));} );
        dropdown.onValueChanged.AddListener(delegate { ChangeType(dropdown.value);} );
    }
    private void ChangeAmount(int newAmount)
    {
        amount = newAmount;
        ClearListeners();
    }
    private void ChangeType(int typeNumber)
    {
        if(typeNumber == 0)
        {
            type = Resources.Types.Gold;
        } else if(typeNumber == 1)
        {
            type = Resources.Types.Stone;
        }
        else if (typeNumber == 2)
        {
            type = Resources.Types.Silver;
        }
        else if (typeNumber == 3)
        {
            type = Resources.Types.Wood;
        }
        else if (typeNumber == 4)
        {
            type = Resources.Types.Bronze;
        }
        ClearListeners();
    }
    private void ClearListeners()
    {
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(() => SingletonInitializer.instance.AddResources(type, amount));
    }
}