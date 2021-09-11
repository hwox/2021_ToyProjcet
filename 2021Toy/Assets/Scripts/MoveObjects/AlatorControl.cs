using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlatorControl : RobotControl
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
