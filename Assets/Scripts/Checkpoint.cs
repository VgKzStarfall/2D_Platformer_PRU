using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public bool isReached = false;
    public Control control;
    public Vector3 resP;
    public AudioSource sound;
    public void SetReached()
    {
        isReached = true;
        sound.Play();
        GetComponent<Animator>().SetTrigger("Activate"); // Optional: play an animation when checkpoint is reached
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SetReached();
            
        }
        
    }
}
