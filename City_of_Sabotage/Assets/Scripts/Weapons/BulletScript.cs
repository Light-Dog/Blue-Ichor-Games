﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public void Setup(Vector3 shootDir)
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        float movespeed = 100f;
        rigidbody.AddForce(shootDir * movespeed, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        AmeliaStats player = other.GetComponent<AmeliaStats>();
        if (player != null)
        {
            print("Hit Player!!!!");
            player.TakeDamage(1);
            Destroy(gameObject);
            return;
        }


        Destructable target = other.GetComponent<Destructable>();
        print("Hit something:" + target.name);

        if (target != null)
        {
            target.TakeDamage(1f);
            Destroy(gameObject);
        }
    }
}
