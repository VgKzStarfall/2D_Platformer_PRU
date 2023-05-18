using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Touch : MonoBehaviour
{
    private Control player;


    void Start()
    {
        player = FindObjectOfType<Control>();
    }

    //MENU BUTTONs
    public void StartG()
    {
        SceneManager.LoadScene("Level1");
        //player.startgame = true;
    }
    public void EndG()
    {
        Application.Quit();
    }
    public void TutorG()
    {
        SceneManager.LoadScene("0Tutorial");
    }
    public void BackG()
    {
        SceneManager.LoadScene("0Menu");
    }

    public void LeftArrow()
    {
        player.moveR = false;
        player.moveL = true;
    }
    public void ReleaseLeftArrow()
    {
        player.moveL = false;
    }
    //
    public void RightArrow()
    {
        player.moveR = true;
        player.moveL = false;
    }
    public void ReleaseRightArrow()
    {
        player.moveR = false;
    }
    //
    public void JumpButton()
    {
        player.jump = true;
    }

}