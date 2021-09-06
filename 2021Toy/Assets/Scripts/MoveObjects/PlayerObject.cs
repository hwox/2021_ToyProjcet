using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObject : MoveObject
{
    int nowType; // yellow & red 
    Transform trans;

    Vector3 transPos, transRot;
    
    [SerializeField]
    GameObject nowPlayRobot;
    public List<GameObject> robots;
    int playType;

    protected bool isMove;
  
    // Start is called before the first frame update
    void Start()
    {
        trans = GetComponent<Transform>();
        playType = 0;
        isNowUseSkill = false;
        nowPlayRobot = robots[playType];
    }

    // Update is called once per frame
    void Update()
    {
        if(isMove)
        {
            move();
            Debug.Log("keep going");
        }
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
    public void playerMove(Vector3 pos)
    {
        if (isMoveEnable)
        {
            transPos = pos;
            isMove = true;
        }
    }

    private void move()
    {
        var dir = transPos - transform.position;
        nowPlayRobot.GetComponent<Transform>().forward = dir;
        transform.position += dir.normalized * Time.deltaTime * 2.0f;

        if (Vector3.Distance(transform.position, transPos) <= 0.1f || !isMoveEnable)
        {
            isMove = false;
        }
    }

    override public void die()
    {

    }

    public void playRobotTypeChange(int type)
    {
        playType = type;
        nowPlayRobot = robots[type];

        for(int i=0;i<robots.Count; ++i)
        {
            if (playType == i)
                robots[i].SetActive(true);
            else
            {
                robots[i].SetActive(false);
            }
        }
    }

}
