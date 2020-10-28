﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponWindCannon : WeaponBase
{
    public Transform firePostion;
    public GameObject coneOfSilence;

    float timer = 0.0f;
    bool isCool = true;

    public override bool Check()
    {
        bool ammoCount = true;

        if (ammo < 0)
        {
            Debug.Log("Wind Cannon Out of Ammo");
            ammoCount = false;
        }

        return (isCool && ammoCount);
    }

    //racsat fire atm
    public override void Fire()
    {
        coneOfSilence.SetActive(true);

        isCool = false;
        timer = 0.0f;
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
                coneOfSilence.SetActive(false);
            }
        }
    }
}
