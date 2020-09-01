using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
  public float spinSpeed = 100f;

    // Update is called once per frame
    void Update()
    {
      float angle = spinSpeed * Time.deltaTime;

      transform.Rotate(Vector3.up * angle, Space.World);
    }
}
