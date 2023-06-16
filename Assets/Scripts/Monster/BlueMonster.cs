using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueMonster : MonsterShared
{
    // Start is called before the first frame update
    void Start()
    {
        MonsterInitial(20,20,10);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
}
