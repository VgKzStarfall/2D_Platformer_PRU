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
    public aMain score;

    // Start is called before the first frame update
    void Start()
    {
        death = GetComponent<TextMeshProUGUI>();
        player = FindObjectOfType<Control>();
        score = FindObjectOfType<aMain>();
    }

    // Update is called once per frame
    void Update()
    {
        death.text = "Death: " + player.deathc;
        valueR = player.deathc;
        if (valueR == 3)
        {
            score.value_score = 0;
            SceneManager.LoadScene("1End");
        }
        aMain.Instance.value_death = valueR;
    }
}
