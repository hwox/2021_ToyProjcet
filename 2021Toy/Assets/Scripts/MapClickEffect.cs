using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapClickEffect : MonoBehaviour
{
    public Material clickPosMaterial;
    float cut;
    bool draw { get; set; }

    void Start()
    {
        
    }

    void Update()
    {
        if(draw)
        {
            cut += Time.deltaTime * 0.5f;
            clickPosMaterial.SetFloat("_Cut", cut);
            if(cut >= 1)
            {
                this.gameObject.SetActive(false);
                draw = false;
            }
        }
    }
    
    public void getMousePos(Vector3 pos)
    {
        cut = 0.1f;
        draw = true;

        pos.y = 0.1f;
        this.transform.position = pos;

        this.gameObject.SetActive(true);
    }
}
