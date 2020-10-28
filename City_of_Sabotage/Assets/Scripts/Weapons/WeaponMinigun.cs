using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMinigun : WeaponBase
{
    public Transform firePostion;
    public Transform player;
    public GameObject impactEffect;
    public GameObject bullet;

    float timer = 0.0f;
    bool isCool = true;

    public override bool Check()
    {
        bool ammoCount = true;

        if (ammo < 0)
        {
            Debug.Log(" Minigun Out of Ammo");
            ammoCount = false;
        }

        return (isCool && ammoCount);
    }

    //racsat fire atm
    public override void Fire()
    {
        //muzzleParticle.Play();

        /*
        RaycastHit hit;
        if(Physics.Raycast(firePostion.position, firePostion.forward, out hit))
        {
            print("I hit " + hit.transform.name);

            Destructable box = hit.transform.GetComponent<Destructable>();
            if(box != null)
            {
                box.TakeDamage(damage);
            }

            Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
        }
        */

        Vector3 middle = firePostion.position;
        //middle.y += 25f;
        GameObject shot = Instantiate(bullet, firePostion.position, firePostion.rotation);
        shot.GetComponent<BulletScript>().Setup(player.forward);

        isCool = false;
        timer = 0.0f;
    }

    //cooldown-update
    void Update()
    {
        if(!isCool)
        {
            timer += Time.deltaTime;
            if(timer > cooldown)
            {
                isCool = true;
            }
        }
    }
}
