using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aMain : MonoBehaviour
{
    // Start is called before the first frame update
    public static aMain Instance;

    public int value_diamond = 0;
    public int value_ruby = 0;
    public int value_death = 0;
    public int value_score = 0;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }    

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

}
