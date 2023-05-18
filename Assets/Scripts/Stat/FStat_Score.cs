using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FStat_Score : MonoBehaviour
{
    public TMP_Text score;
    private aMain result;

    public int finalscore;

    // Use this for initialization
    void Start()
    {
        score = GetComponent<TextMeshProUGUI>();
        result = FindObjectOfType<aMain>();
    }

    void Update()
    {
        finalscore = result.value_score;

        if (true)
        {
            score.text = "Score: " + finalscore;
        }
    }
}