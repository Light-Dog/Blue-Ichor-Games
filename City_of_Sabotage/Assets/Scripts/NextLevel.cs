﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NextLevel : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.gameObject.GetComponent<BoxCollider>())
        {
            //Debug.Log("yoooo");
            SceneManager.LoadScene(2);
        }
    }
}