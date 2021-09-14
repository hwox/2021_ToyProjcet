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
        anim.SetBool("isMove", value);
    }

    protected void skillStateCheck()
    {
        if (isNowUseSkill)
        {
            if (!anim.GetCurrentAnimatorStateInfo(0).IsName("WalkF") &&
                !anim.GetCurrentAnimatorStateInfo(0).IsName("WalkB") &&
                anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.9f)
            {
                if (useSkill == null)
                    return;

                anim.SetInteger("skilltype", 0);
                ObserverManager.Instance.dispatch("SkillEnd");
                isNowUseSkill = false;
            }
        }
    }

    public void skill(SkillData data)
    {
        useSkill = data;
        isNowUseSkill = true;
        anim.SetInteger("skilltype", useSkill.typeId);
        Debug.Log(useSkill.typeId);
    }

    protected void die()
    {
        // anim.SetBool("Die", true);
        Invoke("ActiveEnd()", 3.0f);
    }

    void activeEnd()
    {
        // 사라지는거 쉐이더로 구현해보기
        this.gameObject.SetActive(true);
    }

}
