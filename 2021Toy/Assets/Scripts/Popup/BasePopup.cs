using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasePopup : MonoBehaviour
{ 
    protected Image Dimmed;

    void Start()
    {
        Dimmed = this.transform.Find("Dimmed").GetComponent<Image>();

        // Dimmed 같은 경우에 사용하지 않는 경우가 있음 skill popup 같은 경우
        if (Dimmed != null)
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
        iTween.ScaleTo(gameObject, iTween.Hash("time", 0.5f, "easeType", "easeInOutback"));
    }

    protected void closeTween()
    {
        iTween.ScaleTo(gameObject, iTween.Hash("from", 1, "to", 0, "time", 0.5f, "easeType", "easeInOutback"));
    }
}
