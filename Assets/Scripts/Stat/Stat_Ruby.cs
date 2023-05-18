using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Stat_Ruby : MonoBehaviour
{
    public TMP_Text ruby;
    private Control player;
    public int valueR;

    // Use this for initialization
    void Start()
    {
        ruby = GetComponent<TextMeshProUGUI>();
        player = FindObjectOfType<Control>();
    }

    void Update()
    {
        if (player.rubies == 3)
        {
            ruby.text = "Ruby: " + player.rubies + "/3";
        } else
            ruby.text = "Ruby: " + player.rubies;


        valueR = player.rubies;
        aMain.Instance.value_ruby = valueR;

    }
}