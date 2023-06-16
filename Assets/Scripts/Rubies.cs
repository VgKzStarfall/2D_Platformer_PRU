using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rubies : MonoBehaviour
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
            player.rubies++;
            if (player.curhealth<=50)
            {
                player.curhealth += 50;
            } else
            {
                player.curhealth = 100;
            }
            Destroy(gameObject);
        }
    }
}