using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;

public class DataManager : Singleton<DataManager>
{
    string path; // 불러올 엑셀 파일의 path 

    public enum DataType
    {
        skill,
        item,
        enemy,
        last
    }

    [SerializeField]
    SkillData skillData;
    [SerializeField]
    ScriptData scriptData;
    [SerializeField]
    EnemyData enemyData;
    [SerializeField]
    ItemData itemData;
    

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void init()
    {
        dataRead(path);
    }

    // excel 파일을 읽어오려 했으나 자꾸 Microsoft office관련 참조가 풀리면서 에러 발생
    // -> 구글 스프레드 시트로 하려했으나 굳이 구글 스프레드 시트까지 만들어야 할까? 해서 오픈소스 이용
    void dataRead(string path = "")
    {

        try
        {
            if(path == "")
            {
                throw new System.Exception("path is null");
            }

        }
        catch(Exception e)
        {
            throw e;
        }
    }

}
