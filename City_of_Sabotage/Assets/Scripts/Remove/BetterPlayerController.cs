using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterPlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public float gravityScale;

    public CharacterController controller;
    public Animator anim;

    Vector3 direction;
    bool doubleJump = false;

    //range of (0, 1.0f)
    public float HorizontalAnimSmoothTime = 0.2f;
    public float VerticalAnimTime = 0.2f;
    public float StartAnimTime = 0.3f;
    public float StopAnimTime = 0.15f;

    // Start is called before the first frame update
    void Start()
    {
        //anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        float inputX = Input.GetAxis("Horizontal");
        float inputZ = Input.GetAxis("Vertical");

        float speed = new Vector2(inputX, inputZ).sqrMagnitude;

        if(speed > 0)
        {
            anim.SetFloat("Blend", speed, StartAnimTime, Time.deltaTime);
        }
        else
        {
            anim.SetFloat("Blend", speed, StopAnimTime, Time.deltaTime);
        }
        */

        PlayerMove();
    }

    void PlayerMove()
    {
        float yStore = direction.y;

        direction = ((transform.forward * Input.GetAxisRaw("Vertical")) + (transform.right * Input.GetAxisRaw("Horizontal")));
        direction = direction.normalized * moveSpeed;

        direction.y = yStore;

        if (controller.isGrounded)
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

        direction.y += (Physics.gravity.y * gravityScale * Time.deltaTime);
        controller.Move(direction * Time.deltaTime);
    }
}
