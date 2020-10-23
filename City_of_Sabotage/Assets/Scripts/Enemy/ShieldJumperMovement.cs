using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldJumperMovement : MonoBehaviour
{
    public GameObject ally;
    public Transform target;
    public float trackRange = 20f;
    public float speed = 3.0f;
    public float turnSpeed = 3.0f;
    //public Rigidbody rb;
    public bool isGrounded = false;

    // Start is called before the first frame update
    void Start()
    {
        ally = FindObjectOfType<TrashTrackMove>().gameObject;
        target = ally.transform;
        //rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //jumping

        int layerMask = 1 << 8;
        layerMask = ~layerMask;

        if (Physics.Raycast(transform.position, Vector3.down, 1.0f, layerMask))
        {
            isGrounded = true;
        }
        else 
        { 
            isGrounded = false;
        }

        //movement

        if (ally != null)
        {
            target = ally.transform;
            float step = speed * Time.deltaTime; // calculate distance to move

            float y_trans = transform.position.y;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);

            transform.position = new Vector3(transform.position.x, y_trans, transform.position.z);
        }

        //move towards
        /*
        if (transform.position.y < target.position.y)
        {
            transform.position = new Vector3(transform.position.x, target.position.y, transform.position.z);
        }
        */

        

        //turn facing
        Quaternion targetRotation = Quaternion.LookRotation(target.position - transform.position);
        float str = Mathf.Min(turnSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, str);
    }
}
