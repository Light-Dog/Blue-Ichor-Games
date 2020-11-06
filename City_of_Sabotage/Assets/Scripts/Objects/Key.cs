using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        AmeliaStats player = other.GetComponent<AmeliaStats>();
        if (player != null)
        {
            player.ItemCollect(gameObject);
            Destroy(gameObject);
        }
    }
}
