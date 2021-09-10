﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillSlot : MonoBehaviour
{
    SkillData _data; 

    public Image skillImage;
    public Text skillName;
    public Text skillDesc;
    public Text skillCoolTime;
    public Image skillUseEnable; // 현재 타입에서 해당 스킬이 사용 가능한지

    public Sprite[] enableImage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void skillSlotSet(SkillData data)
    {
        _data = data;

        string imagePath = "Images/" + data.id;
        skillImage.sprite = Resources.Load<Sprite>(imagePath);
        skillName.text = data.name;
        skillDesc.text = data.desc;

        string coolTime = "COOL TIME is " + data.cooltime + "sec";
        skillCoolTime.text = coolTime;

        usableTypeCheck(PlayerManager.Instance.getPlayerNowType());
    }

    // 해당 스킬이 현재 스킬타입과 일치하는지에 따라 slot에 이미지 보여주기 
    public void usableTypeCheck(int nowType)
    {
        if(nowType == _data.type)
        {
            skillUseEnable.sprite = enableImage[0];
        }
        else
        {
            skillUseEnable.sprite = enableImage[1];
        }
    }
}
