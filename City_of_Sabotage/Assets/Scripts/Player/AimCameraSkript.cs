using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimCameraSkript : MonoBehaviour
{
    public float rotationSpeed = 1f;
    public Transform player;
    float mouseX, mouseY;

    // Update is called once per frame
    void Update()
    {
        mouseX += Input.GetAxis("Mouse X") * rotationSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * rotationSpeed;
        mouseY = Mathf.Clamp(mouseY, -35, 60);

        player.rotation = Quaternion.Euler(mouseY, mouseX, 0);
    }
}
