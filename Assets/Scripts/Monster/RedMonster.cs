using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedMonster : MonsterShared
{
    // Start is called before the first frame update
    void Start()
    {
        MonsterInitial(10,10, 5);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
}
