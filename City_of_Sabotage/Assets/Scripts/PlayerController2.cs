using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    public float moveSpeed;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float xSpeed = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float zSpeed = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        rb.velocity = new Vector3(xSpeed, rb.velocity.y, zSpeed);
    }
}
