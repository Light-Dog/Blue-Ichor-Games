using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashTrackMove : MonoBehaviour
{
    public GameObject player;
    public Transform target;

    public float trackRange = 20f;
    public float speed = 3.0f;
    public float turnSpeed = 3.0f;


    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<AmeliaStats>().gameObject;
        target = player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        target = player.transform;
        float step = speed * Time.deltaTime; // calculate distance to move

        float y_trans = transform.position.y;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        transform.position = new Vector3(transform.position.x, y_trans, transform.position.z);

        //turn facing
        Quaternion targetRotation = Quaternion.LookRotation(target.position - transform.position);
        float str = Mathf.Min(turnSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, str);
    }

    private void OnTriggerEnter(Collider other)
    {
        AmeliaStats player = other.GetComponent<AmeliaStats>();
        if (player != null)
        {
            print("Hit Player!!!!");
            player.TakeDamage(1);
        }
    }
}
