using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorcycleRide : MonoBehaviour
{
    //public Rigidbody rb;
    public float speed = 0.01f;

    // Start is called before the first frame update
    void Start()
    {
       // rb = gameObject.GetComponent<Rigidbody>();
        speed = 0.01f;
    }

    // Update is called once per frame
    void Update()
    {
        //rb.AddForce(Vector3.forward * speed);
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + speed);
        speed += 0.005f;
    }
}
