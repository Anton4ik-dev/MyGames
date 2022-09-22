using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputChecker : MonoBehaviour
{
    private void Update()
    {
        if (!CanvasScript.isPaused)
        {
            if (Input.GetButtonDown("Jump"))
            {
                Player._invoker.CallShoot();
            }
            if (Input.GetAxis("Horizontal") != 0)
            {
                float axis = Input.GetAxis("Horizontal");
                Player._invoker.CallMove(axis);
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                CanvasScript.isPaused = false;
                SceneManager.LoadScene(0);
            }
        }
    }
}
