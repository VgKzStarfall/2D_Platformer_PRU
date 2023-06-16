using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    //remove
    private Control player;
    public Transform start;
    public GameObject Explode;
    void Start()
    {
        player = FindObjectOfType<Control>();
    }

    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            StartCoroutine(respawndelay());
        }
    }

    public IEnumerator respawndelay()
    {
        player.deathc++;
        player.curhealth = 0;
        player.enabled = false;
        Instantiate(Explode, player.transform.position, transform.rotation); //edit this line for checkpoint
        //player.enabled = false;
        player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        player.GetComponent<Renderer>().enabled = false;
        yield return new WaitForSeconds(1);
        player.transform.position = player.respawnPoint; // eidt this line for checkpoint
        player.curhealth = player.maxhealth;
        player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        player.GetComponent<Renderer>().enabled = true;
        player.enabled = true;
    }
}