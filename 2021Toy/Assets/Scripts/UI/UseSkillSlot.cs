using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UseSkillSlot : MonoBehaviour, IHashRecv
{
    bool isSkillSetEnable;

    public Sprite standImage;
    public Image cantUseSkill;
    public Image skillImage;
    public Text coolTime;


    SkillData data;
    Image dragImage;

    private void Start()
    {
        isSkillSetEnable = true;
        skillImage = GetComponent<Image>();
        dragImage = this.transform.root.Find("DragSlot").GetComponent<Image>();
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (!isSkillSetEnable)
            return;

        isSkillSetEnable = false;
        data = collision.gameObject.GetComponent<DragSlot>().getSkillData();

        string imagePath = "Images/" + data.id;
        skillImage.sprite = Resources.Load<Sprite>(imagePath);
        isUseSkillCheck();

        Invoke("skillSetEnable", 1.0f);
    }

    void skillSetEnable()
    {
        isSkillSetEnable = true;
    }

    public void OnDragBegin(BaseEventData data)
    {
        dragImage.gameObject.SetActive(true);
        dragImage.GetComponent<RectTransform>().SetAsLastSibling();

        // 현재 선택된 이미지의 스프라이트와 맞춰주기
        dragImage.sprite = skillImage.sprite;
    }

    public void OnDrag(BaseEventData data)
    {
        if (dragImage == null)
            return;

        PointerEventData pointerData = (PointerEventData)data;
        dragImage.transform.position = pointerData.position;
    }

    public void OnDragEnd(BaseEventData data)
    {
        if (dragImage == null)
            return;

        dragImage.gameObject.SetActive(false);
        data = null;
        skillImage.sprite = standImage;
    }

    void isUseSkillCheck()
    {
        if (data.type == PlayerManager.Instance.getPlayerNowType())
            cantUseSkill.gameObject.SetActive(false);
        else
            cantUseSkill.gameObject.SetActive(true);
    }

    public void receiveCall(string key, Hashtable param)
    {
        // 만약에 타입이 바뀌면 타입별로 사용할 수 있는 스킬인지 체크하기 
        if(key == "PlayerTypeChange")
        {
            if (data == null)
                return;

            isUseSkillCheck();
        }
    }
}
