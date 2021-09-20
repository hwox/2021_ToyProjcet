using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapClickEffect : MonoBehaviour
{
    public Material clickPosMaterial;
    public Vector3 mousePos;

    float radius;
    bool draw { get; set; }

    void Start()
    {
        
    }

    void Update()
    {
        if(draw)
        {
            radius += Time.deltaTime;

            if(EGameSetting.MAX_RADIUS < radius)
            {
                draw = false;
                this.gameObject.SetActive(false);
            }

            clickPosMaterial.SetVector("Center", new Vector4(mousePos.x, mousePos.y, mousePos.z, 0));
            clickPosMaterial.SetFloat("Radius", radius);
        }
    }
    
    public void getMousePos(Vector3 pos)
    {
        this.transform.position = pos;
        this.gameObject.SetActive(true);
        mousePos = pos;
        draw = true;
        radius = 0;
    }
}
