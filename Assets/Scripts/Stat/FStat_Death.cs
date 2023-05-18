using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FStat_Death : MonoBehaviour
{

    public TMP_Text death;
    private aMain player;
    public int value;

    // Start is called before the first frame update
    void Start()
    {
        death = GetComponent<TextMeshProUGUI>();
        player = FindObjectOfType<aMain>();
    }

    // Update is called once per frame
    void Update()
    {
        value = -100 * player.value_death;


        if (player.value_death == 0)
        {
            death.text = "Death: NONE! You are.. a god?";
        }
        else
        { 
            death.text = "Death: " + player.value_death + " = " + value; 
        } 

    }
}
