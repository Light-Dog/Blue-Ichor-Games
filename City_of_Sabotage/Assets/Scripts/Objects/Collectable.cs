using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public bool key = false;
    public int numUses = 0;

    private void OnTriggerEnter(Collider other)
    {
        AmeliaStats player = other.GetComponent<AmeliaStats>();
        if (player != null)
        {
            //add key to inventroy
            player.ItemCollect(gameObject);
            //remove key from world
            gameObject.SetActive(false);
        }
    }
}
