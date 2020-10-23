using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlueSpinMovement : MonoBehaviour
{
    public GameObject player;
    public Transform target;
    public float trackRange = 20f;
    public float speed = 4.0f;
    public float turnSpeed = 4.0f;
    //public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<AmeliaStats>().gameObject;
        target = player.transform;
        //rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        target = player.transform;
        float step = speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);

        //move towards
        if (transform.position.y < target.position.y)
        {
            transform.position = new Vector3(transform.position.x, target.position.y, transform.position.z);
        }

        //turn facing
        Quaternion targetRotation = Quaternion.LookRotation(target.position - transform.position);
        float str = Mathf.Min(turnSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, str);
    }
}
