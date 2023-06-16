using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Switch : MonoBehaviour
{
    private Control player;
    private int finalscore;
    private IOFIle file = new IOFIle();

    void Start()
    {
        player = FindObjectOfType<Control>();
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            finalscore = (50 * player.diamonds) + (1000 * player.rubies) + (-100 * player.deathc);
            file.dataFileWriter(finalscore, player.diamonds, player.rubies, player.curTime);
            SceneManager.LoadScene("1End");
        }
    }
}