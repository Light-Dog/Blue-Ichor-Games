using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float rangeY = 2f;
    public float speed = 3f;
    public float direction = 1f;

    Vector3 initalPosition;

    // Start is called before the first frame update
    void Start()
    {
        initalPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //direction 1 = up and 2 = down
        float movementY = Time.deltaTime * speed * direction;
        float newY = transform.position.y + movementY;

        if (Mathf.Abs(newY - initalPosition.y) > rangeY)
            direction = (direction * -1);
        else
            transform.Translate(new Vector3(0, movementY, 0));
    }
}
