using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinTransition : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.gameObject.GetComponent<BoxCollider>())
        {
            SceneManager.LoadScene(3);
        }
    }
}
