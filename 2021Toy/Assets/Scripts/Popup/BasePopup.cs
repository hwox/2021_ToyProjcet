using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasePopup : MonoBehaviour
{
    Button btnClose;
    Image Dimmed;

    void Start()
    {
        btnClose = this.transform.Find("btnClose").GetComponent<Button>();
        Dimmed = this.transform.Find("Dimmed").GetComponent<Image>();

        btnClose.onClick.AddListener(close);
        Dimmed.raycastTarget = true; // 뒤에 클릭 안되게 
    }

    public virtual void init()
    {
        // 처음 만들어졌을 때 

        show();
    }

    public virtual void show()
    {
        showTween();
    }

    public virtual void close()
    {
        closeTween();
    }

    protected void showTween()
    {
        Debug.Log(this + " : showTween");
        iTween.ScaleTo(gameObject, iTween.Hash("time", 0.5f, "easeType", "easeInOutback"));
    }

    protected void closeTween()
    {
        iTween.ScaleTo(gameObject, iTween.Hash("from", 1, "to", 0, "time", 0.5f, "easeType", "easeInOutback"));
    }

    // 팝업을 아예 삭제할 때
    protected void delete()
    {
        btnClose.onClick.RemoveListener(close);
    }
}
