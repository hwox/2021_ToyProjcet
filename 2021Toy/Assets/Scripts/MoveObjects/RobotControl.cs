using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotControl : MonoBehaviour
{
    protected Animator anim;
    protected bool isNowUseSkill;
    protected SkillData useSkill;

    protected void init()
    {
        anim = GetComponent<Animator>();
    }

    public void animMove(bool value)
    {
        Debug.Log("go");
        anim.SetBool("isMove", value);
    }

    public void skill(SkillData data)
    {
        isNowUseSkill = true;
        anim.SetInteger("Skill", 1);
    }
}
