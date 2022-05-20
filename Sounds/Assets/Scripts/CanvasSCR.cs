using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasSCR : MonoBehaviour
{
    public Slider sfx;
    public Slider main;
    public Toggle sfxTog;
    public Toggle mainTog;
    public static float sfxVolume;
    public static float mainVolume;
    private void Start()
    {
        Time.timeScale = 1;
        sfxVolume = PlayerPrefs.GetFloat("sfx");
        mainVolume = PlayerPrefs.GetFloat("main");
        sfx.value = PlayerPrefs.GetFloat("sfx");
        main.value = PlayerPrefs.GetFloat("main");
        if(PlayerPrefs.GetInt("chk1") == 0)
        {
            sfxTog.isOn = false;
        } else
        {
            sfxTog.isOn = true;
        }
        if (PlayerPrefs.GetInt("chk2") == 0)
        {
            mainTog.isOn = false;
        }
        else
        {
            mainTog.isOn = true;
        }
    }
    private void Update()
    {
        if(sfxTog.isOn == false)
        {
            sfxVolume = 0;
            PlayerPrefs.SetInt("chk1", 0);
        } else
        {
            sfxVolume = sfx.value;
            PlayerPrefs.SetInt("chk1", 1);
        }
        if (mainTog.isOn == false)
        {
            mainVolume = 0;
            PlayerPrefs.SetInt("chk2", 0);
        }
        else
        {
            mainVolume = main.value;
            PlayerPrefs.SetInt("chk2", 1);
        }
    }
    public void OnMusicChange()
    {
        mainVolume = main.value;
        PlayerPrefs.SetFloat("main", mainVolume);
    }
    public void OnsfxChange()
    {
        sfxVolume = sfx.value;
        PlayerPrefs.SetFloat("sfx", sfxVolume);
    }
    public void ReloaadScene()
    {
        SceneManager.LoadScene(1);
    }
}
