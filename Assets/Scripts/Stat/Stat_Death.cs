using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Stat_Death : MonoBehaviour
{

    public TMP_Text death;
    private Control player;
    public int valueR;

    // Start is called before the first frame update
    void Start()
    {
        death = GetComponent<TextMeshProUGUI>();
        player = FindObjectOfType<Control>();
    }

    // Update is called once per frame
    void Update()
    {
        death.text = "Death: " + player.deathc;
        valueR = player.deathc;
        if (valueR == 3)
        {
            SceneManager.LoadScene("1End");
        }
        aMain.Instance.value_death = valueR;
    }
}
