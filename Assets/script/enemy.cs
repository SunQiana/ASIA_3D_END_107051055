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
    public GameObject Bullet;
    public GameObject Myself;

    private Transform player;
    private NavMeshAgent nav;
    private Animator anim;
    private float cdTime;

    //抓數據進來
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
        //如果剩餘的距離小於等於設定的暫停距離
        if (nav.remainingDistance <= stopDistance)
        {
            //改變視線方向
            transform.LookAt(new Vector3(player.position.x, transform.position.y, player.position.z));

            //如果cd冷卻了
            if (cdTime >= attackCD)
            {
                anim.SetTrigger("attack");
                cdTime = 0;
            }

        }
    }
    void Track()
    {
        //追蹤
        nav.SetDestination(player.position);

        anim.SetBool("walk", nav.remainingDistance > stopDistance);
    }

    private void OnDrawGizmos()
    {
        //射線還啥的
        Gizmos.color = Color.red;
        Gizmos.DrawRay(atkPoint.position, atkPoint.forward * atkLenght);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Bullet(Clone)")
        {
            anim.SetBool("Dead", true);
            nav.isStopped = (true);
        }
    }
}
