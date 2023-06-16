using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackMonster : MonsterShared
{
    // Start is called before the first frame update
    void Start()
    {
        MonsterInitial(100,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
}
