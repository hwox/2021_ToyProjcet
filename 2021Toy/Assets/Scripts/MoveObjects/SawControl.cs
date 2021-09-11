using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawControl : RobotControl
{
    void Start()
    {
        init();
    }

    void Update()
    {
        skillStateCheck();
    }
}
