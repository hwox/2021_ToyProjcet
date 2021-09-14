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
            Invoke("coolTime", 1.5f); // temp

            for (int i=0;i<2;++i)
            {
                GameObject obj = ObjectPoolManager.Instance.pop(ObjectPoolManager.poolType.bullet);

                if (i % 2 == 0)
                {
                    obj.transform.position = this.transform.position - Vector3.left * 0.4f + Vector3.up * 1.2f; ;
                }
                else
                {
                    obj.transform.position = this.transform.position + Vector3.left * 0.4f + Vector3.up * 1.2f; ;
                }

                obj.GetComponent<Bullet>().init(this.transform.parent.rotation);
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
