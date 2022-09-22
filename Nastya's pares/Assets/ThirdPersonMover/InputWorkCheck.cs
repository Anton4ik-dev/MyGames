using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputWorkCheck : MonoBehaviour
{
    [SerializeField] private TPMPlayerMove _moveScript;
    [SerializeField] private Text _onOffText;
    private void Update()
    {
        if(Input.GetButtonDown("Submit") && _moveScript.enabled)
        {
            _moveScript.enabled = false;
            _onOffText.text = "Выкл";
        } else if(Input.GetButtonDown("Fire1") && !_moveScript.enabled)
        {
            _onOffText.text = "";
            _moveScript.enabled = true;
        }
    }
}
