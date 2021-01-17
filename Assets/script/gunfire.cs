using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class gunfire : MonoBehaviour
{
    public AudioClip FireSound;
    public GameObject BulletPrefab;
    public Transform BulletSpawn;
    public GameObject FireEffect;

    private Animator anim;
    private AudioSource audsorce;

    private void Awake()
    {
        audsorce = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        //如果按下滑鼠左鍵
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Fire();
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            FireEffect.SetActive(false);
        }

            //如果按著滑鼠右鍵
            if (Input.GetKey(KeyCode.Mouse1))
        {
            Aim();
        }
        //若沒按著則取消
        else
        {
            anim.SetBool("aim", false);
        }
    }

    void Fire()
    {
        if (Input.GetKey(KeyCode.Mouse1))

        {
            print("左鍵測試");
            //觸發開火動畫
            anim.SetTrigger("fireing");
            //生成子彈
            GameObject Bullet = (GameObject)Instantiate(BulletPrefab, BulletSpawn.position, BulletSpawn.rotation);
            //子彈射出
            Bullet.GetComponent<Rigidbody>().velocity = Bullet.transform.forward * 60;
            //射程
            Destroy(Bullet, 1.5f);
            //觸發開火特校
            FireEffect.SetActive(true);
            //觸發開火聲音
            audsorce.PlayOneShot(FireSound);
        }
    }

    void Aim()
    {
        print("右鍵測試");
        //觸發移動瞄準動畫
        anim.SetBool("aim", true);
    }
}

