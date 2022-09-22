using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputChecker : MonoBehaviour
{
    [SerializeField] private Text _onOffText;
    private void Update()
    {
        if(Input.GetButtonDown("Submit"))
        {
            _onOffText.text = "Выкл";
        }
        if (Input.GetButtonDown("Fire1"))
        {
            _onOffText.text = "";
        }
        if (_onOffText.text == "")
        {
            if (Input.GetButtonDown("Jump"))
            {
                Invoker.CallJump();
            }
            if (Input.GetAxis("Horizontal") != 0)
            {
                Invoker.CallRotation();
            }
            if (Input.GetAxis("Vertical") > 0)
            {
                Invoker.CallForward();
            }
            if (Input.GetAxis("Vertical") < 0)
            {
                Invoker.CallBack();
            }
        }
    }
}