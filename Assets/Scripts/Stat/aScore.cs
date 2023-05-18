using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class aScore : MonoBehaviour
{ 
    public TMP_Text score;

    private Control player;
    public int valueD, valueR, valueDc;
    public int finalscore;

    // Use this for initialization
    void Start()
    {
        player = FindObjectOfType<Control>();

        score = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {

        valueD = 50 * player.diamonds;
        valueR = 1000 * player.rubies;
        valueDc = -100 * player.deathc;

        finalscore = valueD + valueR + valueDc;

        if (true)
        {
            score.text = "Score: " + finalscore;
        }

        aMain.Instance.value_score = finalscore;
    }
}