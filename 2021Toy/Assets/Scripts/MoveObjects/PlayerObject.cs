using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObject : MoveObject
{
    int nowType; // yellow & red 
    Transform trans;

    Vector3 transPos, transRot;
    Vector3 targetPos, targetRot;

    // Start is called before the first frame update
    void Start()
    {
        trans = GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void useSkill(SkillData skill)
    {
        isNowUseSkill = true;
    }

    public void skillEnd()
    {
        isNowUseSkill = false;
    }

    // 플레이어 움직이는 함수
    public void playerMove(Vector3 Pos)
    {
        if (isMoveEnable)
        {
            Debug.Log("input");
            //  transPos = Camera.main.ScreenToWorldPoint(Pos);
            // targetPos = new Vector3(transPos.x, transPos.y, 0);
            targetPos = Camera.main.ScreenToWorldPoint(Pos);
            targetPos.z = transform.position.z;

            transform.position = Vector3.MoveTowards(transform.position, targetPos, Time.deltaTime * moveSpeed);
        }

       // float rotX = Input.GetAxis("Mouse X") * rotSpeed * Mathf.Deg2Rad;
       // float rotY = Input.GetAxis("Mouse Y") * rotSpeed * Mathf.Deg2Rad;

       // transform.Rotate(Vector3.up, -rotX);
      //  transform.Rotate(Vector3.right, rotY);
    }

    override public void die()
    {

    }
}
