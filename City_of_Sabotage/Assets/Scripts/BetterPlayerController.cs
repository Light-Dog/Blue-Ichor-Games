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
    bool doubleJump = false;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float yStore = direction.y;

        direction = ( (transform.forward * Input.GetAxisRaw("Vertical"))  + (transform.right * Input.GetAxisRaw("Horizontal")) );
        direction = direction.normalized * moveSpeed;

        direction.y = yStore;

        if(controller.isGrounded)
        {
            direction.y = 0.0f;
            if (Input.GetButtonDown("Jump"))
            {
                direction.y = jumpForce;
                doubleJump = true;
            }
        }
        else if (Input.GetButtonDown("Jump") && doubleJump)
        {
            direction.y = jumpForce;
            doubleJump = false;
        }

        direction.y +=  (Physics.gravity.y * gravityScale * Time.deltaTime);
        controller.Move(direction * Time.deltaTime);
    }
}
