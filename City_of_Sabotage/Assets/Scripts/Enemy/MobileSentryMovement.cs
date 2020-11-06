using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileSentryMovement : MonoBehaviour
{
    public GameObject player;
    public Vector3 targetV3;
    public Transform target;

    public GameObject bullet;
    public Transform firePostion;

    public float trackRange = 20f;
    public float speed = 3.0f;
    public float turnSpeed = 3.0f;
    public float fireDistance = 20f;

    public float attackSpeed = 2.5f;

    bool isCool = true;
    float timer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<AmeliaStats>().gameObject;
        
        targetV3.x = transform.position.x + (player.transform.position.x - transform.position.x) / 2;
        targetV3.y = transform.position.y + (player.transform.position.y - transform.position.y) / 2;
        targetV3.z = transform.position.z + (player.transform.position.z - transform.position.z) / 2;

        target = player.transform;
        target.position = new Vector3(targetV3.x, targetV3.y, targetV3.z);
    }

    // Update is called once per frame
    void Update()
    {
        CooldownTimer();

        target = player.transform;
        float step = speed * Time.deltaTime; // calculate distance to move

        if(DistanceCheck())
        {
            fire();
        }
        else
        {
            float y_trans = transform.position.y;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
            transform.position = new Vector3(transform.position.x, y_trans, transform.position.z);
        }

        //turn facing
        Quaternion targetRotation = Quaternion.LookRotation(target.position - transform.position);
        float str = Mathf.Min(turnSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, str);
    }

    bool DistanceCheck()
    {
        //x z 
        float x = (transform.position.x - player.transform.position.x);
        float z = (transform.position.z - player.transform.position.z);

        //if inside the fire range, fire
        if(fireDistance >= Mathf.Sqrt((x*x)+(z*z)) )
        {
            return true;
        }

        //else move
        return false;
    }

    void fire()
    {

        if(isCool)
        {
            print("Sentry is Firing");

            GameObject shot = Instantiate(bullet, firePostion.position, firePostion.rotation);
            shot.GetComponent<BulletScript>().Setup(transform.forward);

            isCool = false;
            timer = 0.0f;
        }
    }

    void CooldownTimer()
    {
        if (!isCool)
        {
            timer += Time.deltaTime;
            if (timer > attackSpeed)
            {
                isCool = true;
            }
        }
    }
}
