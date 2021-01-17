using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 槍基本行爲類
/// </summary> 
[RequireComponent(typeof(AudioSource))]
public class gun : MonoBehaviour
{
    [Header("槍信息")]
    public int ammoCapacity = 15;       //彈匣容量
    public int currentAmmoBullets = 15; //當前彈匣子彈數
    public int remainBullets = 90;      //剩餘子彈數

    [Space]
    public AudioClip Gunshot;   //槍聲
    public AudioClip NoAmmo;    //沒有子彈提示音
    public GameObject bulletPrefab;//子彈預製件
    public Transform firePoint;
    public GameObject fireEffect;

    private AudioSource audioSource;
    protected Animator anim;




    protected virtual void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
    }

    protected virtual void Update()
    {


    }

    // 射擊   
    public void Firing(Vector3 direction)
    {
        if (Ready() == false)
            return;


        audioSource.PlayOneShot(Gunshot);
        anim.SetTrigger("fire");
        //開火特效
        Instantiate(fireEffect, firePoint.position, Quaternion.LookRotation(direction));
        Instantiate(bulletPrefab, firePoint.position, Quaternion.LookRotation(direction));


    }

    //準備子彈
    public bool Ready()
    {
        //如果彈匣内沒有子彈 or 正在播放換彈動畫
        if (currentAmmoBullets <= 0 || anim.GetBool("isReload"))
        {
            audioSource.PlayOneShot(NoAmmo);
            return false;
        }

        currentAmmoBullets--;
        return true;
    }



    // 更換彈夾   
    public void UpdateAmmo()
    {

        if (remainBullets <= 0 || currentAmmoBullets == ammoCapacity)
            return;

        currentAmmoBullets = remainBullets >= ammoCapacity ? ammoCapacity : remainBullets;
        anim.SetTrigger("isReload");
        remainBullets -= currentAmmoBullets;

    }



    //===========================================



}
