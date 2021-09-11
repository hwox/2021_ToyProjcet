using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class PlayerObject : MoveObject, IHashRecv
{
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
       // nav.updateRotation = false; // agent가 캐릭터가 회전시키지 않도록 

        playType = 0;

        isNowUseSkill = false;
        isMove = false;
        nowPlayRobot = robots[playType];

        ObserverManager.Instance.registerEvent("SkillEnd", this);
    }

    // Update is called once per frame
    void Update()
    {
       if (isMove)
        {
            move();
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
            nav.SetDestination(pos);
            transPos = pos;
            nowPlayRobot.GetComponent<RobotControl>().animMove(true);
            isMove = true;
        }
    }

    private void move()
    {
        if ((nav.velocity.magnitude >= 0.1f && nav.remainingDistance <= 0.2f)
            || !isMoveEnable)
        {
            isMove = false;
            nowPlayRobot.GetComponent<RobotControl>().animMove(false);
            return;
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

    public void OnCollisionEnter(Collision collision)
    {
        Hashtable hash = new Hashtable();
        hash.Add("damage", 5);
        ObserverManager.Instance.dispatch(EGameSetting.HP_MINUS, hash);
    }

    public void playerSkillUse(SkillData data)
    {
        isNowUseSkill = true;
        nowPlayRobot.GetComponent<RobotControl>().skill(data);
    }

    public void receiveCall(string key, Hashtable param)
    {
        if(key == "SkillEnd")
        {
            Debug.Log("SkillEnd call");
            isNowUseSkill = false;
        }
    }
}
