using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraContorller : MonoBehaviour
{
    public Transform target;
    public Transform pivot;

    public Vector3 offset;

    public bool useOffset;
    public bool invertYAxis;

    public float spinSpeed;
    public float maxAngleView;
    public float minAngleView;

    // Start is called before the first frame update
    void Start()
    {
        if(!useOffset)
            offset = target.position - transform.position;

        pivot.transform.position = target.transform.position;
        pivot.transform.parent = target.transform;

        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //get the x_position fo the mouse & rotate the target
        float horizontal = Input.GetAxis("Mouse X") * spinSpeed;
        target.Rotate(0, horizontal, 0);
        //get the y_position of the mouse & rotate the pivot;
        float vertical = Input.GetAxis("Mouse Y") * spinSpeed;
        if(invertYAxis)
            pivot.Rotate(vertical, 0, 0);
        else
            pivot.Rotate(-vertical, 0, 0);

        if (pivot.rotation.eulerAngles.x > 45.0f && pivot.rotation.eulerAngles.x < 180.0f)
            pivot.rotation = Quaternion.Euler(maxAngleView, 0, 0);
        if (pivot.rotation.eulerAngles.x > 180.0f && pivot.rotation.eulerAngles.x < 315.0f)
            pivot.rotation = Quaternion.Euler(360f + minAngleView, 0, 0);

        //Move camera based on target rotation and offset
        float desiredY = target.eulerAngles.y;
        float desierdX = pivot.eulerAngles.x;
        Quaternion rotation = Quaternion.Euler(desierdX, desiredY, 0);
        transform.position = target.position - (rotation * offset);

        if (transform.position.y < (target.position.y-0.7f))
            transform.position = new Vector3(transform.position.x, target.position.y - 0.8f, transform.position.z);

        //look at player
        transform.LookAt(target);
    }
}
