using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileSentryMovement : MonoBehaviour
{
    public GameObject player;
    public Vector3 targetV3;
    public Transform target;
    public float trackRange = 20f;
    public float speed = 3.0f;
    public float turnSpeed = 3.0f;
    //public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<AmeliaStats>().gameObject;
        
        targetV3.x = transform.position.x + (player.transform.position.x - transform.position.x) / 2;
        targetV3.y = transform.position.y + (player.transform.position.y - transform.position.y) / 2;
        targetV3.z = transform.position.z + (player.transform.position.z - transform.position.z) / 2;

        target = player.transform;
        target.position = new Vector3(targetV3.x, targetV3.y, targetV3.z);

        //rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //target = player.transform;
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
