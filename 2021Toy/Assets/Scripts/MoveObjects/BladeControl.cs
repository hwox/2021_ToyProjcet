﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeControl : RobotControl
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
