using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody rig;

    private void Start()
    {
        rig = GetComponent<Rigidbody>();
    }

    void Update()
    {
        transform.Translate(new Vector3(0, 0, Time.deltaTime * 20.0f));
    }

    public void init(Quaternion rot)
    {
        Invoke("activeEnd", 3.0f);
        this.transform.rotation = rot;
        this.gameObject.SetActive(true);
    }

    void activeEnd()
    {
        this.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        activeEnd();
        if (collision.gameObject.layer == LayerMask.NameToLayer("Map"))
        {
            Debug.Log("map");
        }
    }
}
