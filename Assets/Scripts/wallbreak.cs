using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class wallbreak : MonoBehaviour
{
    public ParticleSystem destroy;
    public AudioSource breaksound;
    public Slider healthbar;
    void Update()
    {
        if(healthbar.value <= 0)
        {
            SceneManager.LoadScene("gameover");
        }
    }
    public void OnTriggerEnter(Collider collision)
    {
        Debug.Log("collions");
        if (collision.gameObject.tag == "player")
        {
            breaksound.Play();
            Instantiate(destroy.gameObject, transform.position, transform.rotation);
            healthbar.value = healthbar.value - 10;
            gameObject.SetActive(false);
        }
    }
}
