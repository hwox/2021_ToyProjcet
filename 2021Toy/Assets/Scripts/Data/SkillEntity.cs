using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class SkillEntity
{
    public int id;
    public string name;
    public skillType type;
    public int needMp;
    public string desc;
}

public enum skillType
{
    red,
    yellow,
    blue
}

