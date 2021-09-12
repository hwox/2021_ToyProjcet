using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObject : MoveObject
{
    public GameObject enemyOrigin; // spawn되는 enemy의 원본 프리팹
    EnemyControl enemyCtrl;
    bool isDeath; // 죽었는지
    float reSpawnTime;
    float reSpawnRemainTime; 

    void Start()
    {
        GameObject obj = Instantiate(enemyOrigin, this.transform);
        obj.transform.SetParent(this.transform);
        enemyCtrl = transform.GetChild(0).GetComponent<EnemyControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isDeath)
        {

        }
    }

    override public void die()
    {
        Invoke("resetSetting", 3.0f);
    }

    void resetSetting()
    {
        isDeath = false;
        reSpawnRemainTime = reSpawnTime;
    }
}
