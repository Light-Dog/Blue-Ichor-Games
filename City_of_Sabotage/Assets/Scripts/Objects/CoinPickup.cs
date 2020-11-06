using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    public int value = 0;

    private void OnTriggerEnter(Collider other)
    {
        AmeliaStats player = other.GetComponent<AmeliaStats>();
        if(player != null)
        {
            player.GearCollect(value);
            Destroy(gameObject);
        }
    }
}
