using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class FStat_Ruby : MonoBehaviour
{
    public TMP_Text ruby;
    private aMain player;
    public int value;

    // Use this for initialization
    void Start()
    {
        ruby = GetComponent<TextMeshProUGUI>();
        player = FindObjectOfType<aMain>();
    }

    void Update()
    {
        value = 1000 * player.value_ruby;

        if (player.value_ruby == 0)
        {
            ruby.text = "Sadly, no rubies were collected...";
        } else if (player.value_ruby == 3)
        {
            ruby.text = "All 3 rubies collected! = +" + value;
        } else
        {
            ruby.text = "Ruby: " + player.value_ruby + "/3 = +" + value;
        }

    }
}