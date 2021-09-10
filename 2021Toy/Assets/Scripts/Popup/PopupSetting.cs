using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupSetting : BasePopup
{
    public Button btnClose;

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
    }

    public override void close()
    {
        base.close();
        PopupManager.Instance.close("PopupSetting");
    }
}
