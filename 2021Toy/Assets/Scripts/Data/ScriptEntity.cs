using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptEntity
{
    public int              id;
    public scriptType     type; //해당 스크립트가 언제 나오는 스크립트인지 
    public string          txt;
}

public enum scriptType
{
    start,
    end
}
