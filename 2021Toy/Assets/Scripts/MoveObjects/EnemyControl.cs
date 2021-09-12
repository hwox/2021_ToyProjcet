using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyControl : RobotControl
{
    // Start is called before the first frame update
    NavMeshAgent nav;
    Transform destPlayer;

    void Start()
    {
        nav = GetComponent<NavMeshAgent>();

        // enemy는 나중에 3초 후에 spawn 처리 할거라서 우선 이렇게 테스트
        Invoke("getPlayer", 1.0f);
    }

    void Update()
    {
        if (destPlayer == null)
            return;
        distanceFromPlayer();
    }

    void distanceFromPlayer()
    {
        if(Vector3.Distance(destPlayer.position, transform.position) <= 50.0f)
        {
            nav.SetDestination(destPlayer.position);
        }
    }

    void getPlayer()
    {
        destPlayer = PlayerManager.Instance.player.GetComponent<Transform>();

    }
}
