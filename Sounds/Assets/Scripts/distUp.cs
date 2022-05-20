using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class distUp : MonoBehaviour
{
    public AudioDistortionFilter sound;
    public float remainTime = 0.3f;
    private bool check = false;
    private void Start()
    {
        sound = GameObject.Find("MainTheme").GetComponent<AudioDistortionFilter>();
    }
    void Update()
    {
        if(check)
        {
            remainTime -= Time.deltaTime;
            if (remainTime < 0)
            {
                sound.distortionLevel = 0f;
                remainTime = 0.3f;
                check = false;
            }
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            sound.distortionLevel = 0.9f;
            check = true;
        }
    }
}
