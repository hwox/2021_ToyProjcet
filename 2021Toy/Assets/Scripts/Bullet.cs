using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody rig;

    private void Start()
    {
        rig = GetComponent<Rigidbody>();
        rig.AddForce(Vector3.forward * 300.0f);
    }

    void Update()
    {

    }

    public void init()
    {
        Invoke("activeEnd", 3.0f);
    }

    void activeEnd()
    {
        this.gameObject.SetActive(false);
    }
}
