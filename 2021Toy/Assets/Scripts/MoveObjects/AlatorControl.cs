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
        if (isNowUseSkill)
        {
            // 애니메이션 state 체크용 디버깅 로그 
            AnimatorClipInfo[] m_CurrentClipInfo;
            m_CurrentClipInfo = this.anim.GetCurrentAnimatorClipInfo(0);
            Debug.Log(m_CurrentClipInfo[0].clip.name);


            if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.9f)
            {
                anim.SetInteger("Skill", 0);
                ObserverManager.Instance.dispatch("SkillEnd");
                isNowUseSkill = false;
            }
        }
    }

}
