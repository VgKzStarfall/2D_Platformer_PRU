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
            Destroy(gameObject);
        }
    }
}