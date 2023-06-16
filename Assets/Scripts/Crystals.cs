using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystals : MonoBehaviour
{

    private Control player;
    public AudioSource bling;

    void Start()
    {
        player = FindObjectOfType<Control>();
    }

    void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            bling.Play();
            player.diamonds++;
            if (player.curhealth<=98)
            {
                player.curhealth += 2;
            }
            else
            {
                player.curhealth = 100;
            }
            Destroy(gameObject);
        }
    }
}