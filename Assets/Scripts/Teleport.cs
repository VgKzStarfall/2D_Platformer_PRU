using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    private Control player;
    public Transform dest;
    public GameObject telebeam;

    // Start is called before the first frame update
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
            StartCoroutine("teleport");
        }
    }

    /*
    -green particle: tele-in
    -red particle: tele-out
    -blue particle: tele-2way
    */
    public IEnumerator teleport()
    {
        Instantiate(telebeam, player.transform.position, player.transform.rotation);
        player.enabled = false;
        player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        player.GetComponent<Renderer>().enabled = false;
        yield return new WaitForSeconds((float)0.5);
        player.transform.position = dest.position + new Vector3((float)0.1,0,0);
        player.GetComponent<Renderer>().enabled = true;
        player.enabled = true;
        
    }
}
