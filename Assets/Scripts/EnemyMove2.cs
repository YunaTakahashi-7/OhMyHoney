using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyMove2 : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject defposi;
    private NavMeshAgent navMeshAgent;
    private float distance;
    private bool chase;
    public Animator Animator;

    void Start()
    {
        // NavMeshAgentを保持しておく
        navMeshAgent = GetComponent<NavMeshAgent>();
        chase = false;

    }

    // Update is called once per frame
    void Update()
    {
        //二者間の距離を計算してfloat　一定値いかになれば追跡する
        distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance < 5)
        {
            chase = true;           
        }
        else
        {
            chase = false;
        }

        if (chase)
        {
            navMeshAgent.destination = player.transform.position;
            Animator.Play("chase");
        }
        else
        {
            navMeshAgent.destination = defposi.transform.position;
            Animator.Play("walk");
        }
    }

}
