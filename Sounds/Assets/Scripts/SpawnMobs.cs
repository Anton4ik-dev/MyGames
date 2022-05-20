using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnMobs : MonoBehaviour
{
    public float speed;
    public AudioSource dead;
    private Text life;
    
    private void Start()
    {
        life = GameObject.Find("Life").GetComponent<Text>();
    }
    void Update()
    {
        gameObject.GetComponent<Rigidbody>().velocity = -transform.forward * speed;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            dead.volume = CanvasSCR.sfxVolume;
            dead.Play();
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider>().enabled = false;
            Destroy(gameObject, 2);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            life.text = $"{int.Parse(life.text) - 1}";
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider>().enabled = false;
            Destroy(gameObject, 2);
            if (int.Parse(life.text) == 0)
            {
                Time.timeScale = 0;
                RightSpawnMobs.EndGame();
            }
        }
    }
}
