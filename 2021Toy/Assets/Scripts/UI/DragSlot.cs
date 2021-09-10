using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragSlot : MonoBehaviour
{
    SkillData data;

    public void Start()
    {
        this.gameObject.SetActive(false);
    }

    public void setDragSlotSkillData(SkillData skill)
    {
        data = skill; 
    }

    public SkillData getSkillData()
    {
        return data;
    }
}
