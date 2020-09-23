using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCryogun : WeaponBase
{
    public Transform firePostion;

    float timer = 0.0f;
    bool isCool = true;

    public override bool Check()
    {
        bool ammoCount = true;

        if (ammo < 0)
        {
            Debug.Log("Cryogun Out of Ammo");
            ammoCount = false;
        }

        return (isCool && ammoCount);
    }

    //racsat fire atm
    public override void Fire()
    {
        RaycastHit hit;
        if (Physics.Raycast(firePostion.position, firePostion.forward, out hit))
        {
            print("I hit " + hit.transform);
            isCool = false;
            timer = 0.0f;
        }
    }

    //cooldown-update
    void Update()
    {
        if (!isCool)
        {
            timer += Time.deltaTime;
            if (timer > cooldown)
            {
                isCool = true;
            }
        }
    }
}
