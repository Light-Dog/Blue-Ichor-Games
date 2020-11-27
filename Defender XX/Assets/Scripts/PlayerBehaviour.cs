using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public int lives;
    public int ammo;
    public float moveDirection = 0.0f;
    public float moveSpeed = 1.0f;
    public Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {

        //movement horizontal
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown (KeyCode.A))
        {
            moveDirection = -90f;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            moveDirection = 90f;
        }

        //movement vertical
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            //moveDirection = -90f;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            //moveDirection = 90f;
        }

        //apply movement
        rb2d.AddForce(transform.up * moveSpeed);

        //shooting
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.M))
        {
            if (ammo > 0)
            {
                ammo--;
            }
            else 
            {
                Debug.Log("Out of ammo");
            }
        }

        //lives
        if (lives < 0)
        {
            Debug.Log("Game over");
        }

    }
}
