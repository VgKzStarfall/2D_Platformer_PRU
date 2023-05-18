using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Stat_Diamond : MonoBehaviour
{
    public TMP_Text diamond;
    private Control player;
    public int valueR;

    // Use this for initialization
    void Start()
    {
        diamond = GetComponent<TextMeshProUGUI>();
        player = FindObjectOfType<Control>();
    }

    void Update()
    {
        diamond.text = "Diamond: " + player.diamonds + "/75";
        valueR = player.diamonds;
        aMain.Instance.value_diamond = valueR;
    }
}