using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public float gravityScale;
    public float turnSmoother = .1f;

    //range of (0, 1.0f)
    public float HorizontalAnimSmoothTime = 0.2f;
    public float VerticalAnimTime = 0.2f;
    public float StartAnimTime = 0.3f;
    public float StopAnimTime = 0.15f;
    Animator anim;
    bool has_anim = false;

    public CharacterController controller;
    public Transform cam;

    float turnVelocity;
    bool doubleJump = false;

    Vector3 direction;
    Vector3 jump;

    // Start is called before the first frame update
    void Start()
    {
        if (GetComponent<Animator>())
        {
            anim = GetComponent<Animator>();
            has_anim = true;
        }
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        playerMovement();
    }

    void playerMovement()
    {
        float vertical = Input.GetAxisRaw("Vertical");
        float horizontal = Input.GetAxisRaw("Horizontal");

        //Jump code
        if(controller.isGrounded)
        {
            jump.y = -1.0f;

            if(Input.GetButtonDown("Jump"))
            {
                jump.y = jumpForce;
                doubleJump = true;
            }
        }
        else if(Input.GetButtonDown("Jump") && doubleJump)
        {
            jump.y = jumpForce;
            doubleJump = false;
        }

        //Animation code
        if(has_anim)
        {
            float speed = new Vector2(horizontal, vertical).sqrMagnitude;

            if (speed > 0)
            {
                anim.SetFloat("Blend", speed, StartAnimTime, Time.deltaTime);
            }
            else
            {
                anim.SetFloat("Blend", speed, StopAnimTime, Time.deltaTime);
            }
        }

        //Move Code
        direction = new Vector3(horizontal, 0f, vertical).normalized;
        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnVelocity, turnSmoother);
            //rotate the player based on input
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            moveDir = moveDir.normalized * moveSpeed;

            controller.Move(moveDir * Time.deltaTime);
        }

        jump.y += (Physics.gravity.y * gravityScale * Time.deltaTime);
        controller.Move(jump * Time.deltaTime);
    }
}
