using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupSkill : BasePopup
{
    public Button btnClose;
    public GameObject content;
    GameObject skillSlot;

    List<SkillData> skills;

    void Start()
    {
        btnClose.onClick.AddListener(close);
    }

    public override void show()
    {
        base.show();
    }


    public override void init()
    {
        // 처음 생성될 때 
        base.init();
        show();
        Debug.Log(this.name + " init create");
        skills = DataManager.Instance.getSkillData();
        initSkillSlotSet();
    }

    public override void close()
    {
        base.close();
        PopupManager.Instance.close("PopupSkill");
    }

    // 파싱해온 스킬데이터들을 팝업으로 보여줄 때 
    void initSkillSlotSet()
    {
        for(int i=0;i<skills.Count;++i)
        {
            GameObject obj = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/SkillSlot"));
            obj.transform.parent = content.transform;
            obj.transform.localPosition = new Vector3(0, 80 + (-i * 100), 0);
            obj.SetActive(true);
            obj.GetComponent<SkillSlot>().skillSlotSet(skills[i]);
        }
    }
}
