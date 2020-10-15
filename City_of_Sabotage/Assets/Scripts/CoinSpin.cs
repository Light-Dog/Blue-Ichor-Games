using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpin : MonoBehaviour
{
    public float yAngle;
    private float xAngle, zAngle;

    // Start is called before the first frame update
    void Start()
    {
        if (yAngle == 0f || yAngle == 1.1f)
        yAngle = 1.1f;
        xAngle = 0.0f;
        zAngle = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        //spin the coin
        this.transform.Rotate(xAngle, yAngle, zAngle, Space.Self);
    }
}
