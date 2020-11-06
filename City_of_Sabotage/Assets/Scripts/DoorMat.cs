using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMat : MonoBehaviour
{
    public GameObject doorhinge;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<AmeliaStats>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.gameObject.GetComponent<AmeliaStats>())
        {
            doorhinge.GetComponent<AnimControl>().StartAnim();
        }
    }

}
