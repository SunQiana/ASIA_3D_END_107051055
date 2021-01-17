using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 單發槍 繼承GUN類
/// </summary>
public class SingleGun : gun
{
    public Text currentBullets;

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        RaycastHit rHit;
        Debug.DrawRay(firePoint.position, fwd, Color.green);
        if (Physics.Raycast(base.firePoint.position, fwd, out rHit, 100f))
        {

        }

        if (Input.GetMouseButtonDown(0))
        {

            base.Firing(transform.forward * 10);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            base.UpdateAmmo();

        }
        currentBullets.text = base.currentAmmoBullets.ToString();

    }
}
