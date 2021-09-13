using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlatorControl : RobotControl
{
    bool isFireBullet;

    void Start()
    {
        init();
    }

    void Update()
    {
        skillStateCheck();
        if(anim.GetCurrentAnimatorStateInfo(0).IsName("Skill1"))
        {
            if (isFireBullet)
                return;

            isFireBullet = true;
            Invoke("coolTime", 3.0f); // temp

            for (int i=0;i<4;++i)
            {
                GameObject obj = ObjectPoolManager.Instance.pop(ObjectPoolManager.poolType.bullet);
                obj.SetActive(true);
                obj.transform.position = this.transform.position - Vector3.left * (0.3f * i) + Vector3.forward + Vector3.up * 1.7f; ;
                obj.GetComponent<Bullet>().init();
            }
        }
    }

    void coolTime()
    {
        if(isFireBullet)
        {
            isFireBullet = false;
        }
    }
}
