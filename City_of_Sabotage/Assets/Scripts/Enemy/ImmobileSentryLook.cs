using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImmobileSentryLook : MonoBehaviour
{
    public GameObject player;
    public Transform target;
    public float turnSpeed = 4.0f;
    public float range = 4.0f;
    public float Dist = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<AmeliaStats>().gameObject;
        target = player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Dist = Vector3.Distance(transform.position, target.position);
        if (Vector3.Distance(transform.position, target.position) < range)
        {
            this.gameObject.GetComponentInChildren<Animator>().enabled = false;
            Quaternion targetRotation = Quaternion.LookRotation(target.position - transform.position);
            float str = Mathf.Min(turnSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, str);
        }
        else
        {
            this.gameObject.GetComponentInChildren<Animator>().enabled = true;
        }
    }
}
