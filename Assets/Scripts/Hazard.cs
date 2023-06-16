using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    //remove
    private Control player;
    public Transform start;
    public GameObject Explode;
    void Start()
    {
        player = FindObjectOfType<Control>();
    }

    void Update()
    {
    }
}