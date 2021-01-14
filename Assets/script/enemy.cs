using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy : MonoBehaviour
{
    [Header("速度"), Range(0f, 50f)]
    public float speed;

    [Header("距離"), Range(0f, 10f)]
    public float stopDistance;

    [Header("CD"), Range(0f, 10f)]
    public float attackCD;

    public Transform atkPoint;
    public float atkLenght;

    private Transform player;
    private NavMeshAgent nav;
    private Animator anim;
    private float cdTime;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        nav.speed = speed;
        nav.stoppingDistance = stopDistance;

    }
    private void Update()
    {
        cdTime += Time.deltaTime;

        Track();

        Attack();

    }
    void Attack()
    {
        if (nav.remainingDistance <= stopDistance)
        {
            transform.LookAt(new Vector3(player.position.x, transform.position.y, player.position.z));

            if (cdTime >= attackCD)
            {
                anim.SetTrigger("attack");
                cdTime = 0;
            }

        }
    }
    void Track()
    {
        nav.SetDestination(player.position);

        anim.SetBool("walk", nav.remainingDistance > stopDistance);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(atkPoint.position, atkPoint.forward * atkLenght);
    }
}
