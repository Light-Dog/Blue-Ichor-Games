using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMat : MonoBehaviour
{
    public GameObject doorhinge;
    public GameObject player;
    public float range = 15.0f;
    public KeyCode openKey = KeyCode.O;
    public bool opened = false;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<AmeliaStats>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {

        if (opened == false)
        {
            //open with "O" button
            if (Input.GetKeyDown(openKey))
            {
                if (1 == 1) // if player has the key
                {
                    if (Vector3.Distance(gameObject.transform.position, player.transform.position) < range)
                    {
                        doorhinge.GetComponent<AnimControl>().StartAnim();
                        opened = true;
                    }
                }
            }

            //open in range with key
            if (Vector3.Distance(gameObject.transform.position, player.transform.position) < range)
            {
                if (1 == 1) // if player has the key
                {
                    doorhinge.GetComponent<AnimControl>().StartAnim();
                    opened = true;
                }
            }
        }
        else
        { 
            //nothing for now
        }
    }

}
