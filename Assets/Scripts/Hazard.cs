using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine("respawndelay");
            player.deathc++;
        }
    }

    public IEnumerator respawndelay()
    {
        
        Instantiate(Explode, player.respawnPoint, player.transform.rotation); //edit this line for checkpoint
        player.enabled = false;
        player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        player.GetComponent<Renderer>().enabled = false;
        yield return new WaitForSeconds(1);
        player.transform.position = player.respawnPoint; // eidt this line for checkpoint
        player.GetComponent<Renderer>().enabled = true;
        player.enabled = true;
    }
}