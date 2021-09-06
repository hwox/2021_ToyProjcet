using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


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

    private NavMeshAgent nav;
  
    // Start is called before the first frame update
    void Start()
    {
        trans = GetComponent<Transform>();
        nav = GetComponent<NavMeshAgent>();
        nav.updateRotation = false; // agent가 캐릭터가 회전시키지 않도록 

        playType = 0;

        isNowUseSkill = false;
        nowPlayRobot = robots[playType];

        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void LateUpdate()
    {
        if (isMove)
        {
            move();
            Debug.Log("keep going");
        }
    }

    private void FixedUpdate()
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
    public void playerMove(Vector3 pos)
    {
        if (isMoveEnable)
        {
            nav.SetDestination(pos);
            transPos = pos;
            isMove = true;
        }
    }

    private void move()
    {
        if (nav.velocity.magnitude == 0.1f || !isMoveEnable)
        {
            isMove = false;
            return;
        }

        var dir = new Vector3(nav.steeringTarget.x, transform.position.y, nav.steeringTarget.z) - transform.position;
        nowPlayRobot.GetComponent<Transform>().forward = dir;
        //transform.position += dir.normalized * Time.deltaTime * 2.0f;
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
