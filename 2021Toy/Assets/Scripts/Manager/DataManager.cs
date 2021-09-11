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
        script,
        item,
        enemy,
        last
    }

    public List<Dictionary<string, object>> skillData;
    List<Dictionary<string, object>> scriptData;
    List<Dictionary<string, object>> enemyData;
    List<Dictionary<string, object>> itemData;

    [SerializeField]
    List<SkillData> skills = new List<SkillData>();

    public void init()
    {
        dataRead((int)DataType.skill);

       
    }

    // excel 파일을 읽어오려 했으나 자꾸 Microsoft office관련 참조가 풀리면서 에러 발생
    // -> 구글 스프레드 시트로 하려했으나 굳이 구글 스프레드 시트까지 만들어야 할까? 해서 
    // 그냥 csv를 파싱해오기로 했다. CSVReader는 오픈소스 이용
    void dataRead(int type, string path = "")
    {
        if (type == (int)DataType.skill)
        {
            skillData = CSVReader.Read("Skill");
        }
        else if (type == (int)DataType.script)
        {
            scriptData = CSVReader.Read("Script");
        }
        else if (type == (int)DataType.item)
        {
            itemData = CSVReader.Read("Item");
        }
        else if (type == (int)DataType.enemy)
        {
            enemyData = CSVReader.Read("Enemy");
        }
    }

    public List<SkillData> getSkillData()
    {
        List<SkillData> lists = new List<SkillData>();
        for (int i = 0; i < skillData.Count; ++i)
        {
            SkillData temp = new SkillData();
            temp.id = System.Convert.ToInt32(skillData[i]["id"]);
            temp.name = skillData[i]["name"].ToString();
            temp.type = System.Convert.ToInt32(skillData[i]["type"]);
            temp.typeId = System.Convert.ToInt32(skillData[i]["typeId"]);
            temp.desc = skillData[i]["desc"].ToString();
            temp.time = System.Convert.ToInt32(skillData[i]["time"]);
            temp.cooltime = System.Convert.ToInt32(skillData[i]["cooltime"]);
            lists.Add(temp);
        }
        return lists;
    }
}
