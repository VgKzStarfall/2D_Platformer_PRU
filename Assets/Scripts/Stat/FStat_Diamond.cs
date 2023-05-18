using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FStat_Diamond : MonoBehaviour
{
    public TMP_Text diamond;
    private aMain player;
    public int value;

    // Use this for initialization
    void Start()
    {
        diamond = GetComponent<TextMeshProUGUI>();
        player = FindObjectOfType<aMain>();
    }

    void Update()
    {
        value = 50 * player.value_diamond;

        if (player.value_diamond == 0)
        {
            diamond.text = "Somehow, you managed to not collect any diamonds...";
        } else if (player.value_diamond == 75)
        {
            diamond.text = "A diamond lover indeed. No diamonds were forgotten. = +" + value;
        } else
        {
            diamond.text = "Diamond: " + player.value_diamond + "/75 = +" + value;
        }


    }
}