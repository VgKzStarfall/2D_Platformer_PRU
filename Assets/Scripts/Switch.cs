using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Switch : MonoBehaviour
{
    private Control player;


    void Start()
    {
        player = FindObjectOfType<Control>();
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            SceneManager.LoadScene("1End");
        }
    }
}