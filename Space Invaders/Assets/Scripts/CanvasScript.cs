using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasScript : MonoBehaviour
{
    public static bool isPaused = false;
    public void Restart()
    {
        isPaused = false;
        SceneManager.LoadScene(0);
    }
}
