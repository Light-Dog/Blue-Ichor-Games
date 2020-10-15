using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{
    public float health;
    public int gGears;
    public int sGears;
    public int bGears;

    public GameObject destroyed;

    public void TakeDamage(float damage)
    {
        health -= damage;
        print(transform.name + "Health remaining: " + health);

        if (health <= 0f)
        {
            Instantiate(destroyed, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
