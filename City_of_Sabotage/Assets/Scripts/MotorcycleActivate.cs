using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorcycleActivate : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject otherMotorcycle;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        otherMotorcycle.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("oh");
        {
            player.SetActive(false);
            mainCamera.SetActive(false);
            otherMotorcycle.SetActive(true);
        }
    }
}
