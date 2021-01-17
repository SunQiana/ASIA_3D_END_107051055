using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 子彈 
/// </summary>
public class Bullet : MonoBehaviour
{
    public float attackDistanec = 100f;
    protected RaycastHit hit;
    private Vector3 targetPos;
    public float moveSpeed = 50f;
    public LayerMask layer;
    //計算目標點
    private void Awake()
    {
        CalculateTargetPoint();
    }

    private void CalculateTargetPoint()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, attackDistanec, layer))
        {
            targetPos = hit.point;
            GenerateContactEffect();
        }
        else
        {
            targetPos = transform.position + transform.forward * attackDistanec;
            GenerateContactEffect();
        }

    }
    //移動



    private void Update()
    {
        Movement();
        if ((transform.position - targetPos).sqrMagnitude < 0.1f)
        {
            Destroy(gameObject);
        }
    }
    private void Movement()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
    }



    public GameObject ExplosionEffects;
    private void GenerateContactEffect()
    {
        Instantiate(ExplosionEffects, targetPos, Quaternion.identity);




    }

}
