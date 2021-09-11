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
            // 애니메이션 state 체크용 디버깅 로그 
            AnimatorClipInfo[] m_CurrentClipInfo;
            m_CurrentClipInfo = this.anim.GetCurrentAnimatorClipInfo(0);
            Debug.Log(m_CurrentClipInfo[0].clip.name);

            Debug.Log("Now Skill Use ing");

            if (!anim.GetCurrentAnimatorStateInfo(0).IsName("WalkF") &&
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
}
