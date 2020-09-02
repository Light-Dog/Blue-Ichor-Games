using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterPlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public float gravityScale;

    public CharacterController controller;

    Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float xSpeed = Input.GetAxis("Horizontal") * moveSpeed;// * Time.deltaTime;
        float zSpeed = Input.GetAxis("Vertical") * moveSpeed;// * Time.deltaTime;

        direction = new Vector3(xSpeed, 0.0f, zSpeed);

        if (Input.GetButtonDown("Jump"))
        {
            direction.y = jumpForce;
        }

        direction.y = direction.y + (Physics.gravity.y * gravityScale);
        controller.Move(direction * Time.deltaTime);
    }
}
