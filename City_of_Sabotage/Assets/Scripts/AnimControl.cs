using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimControl : MonoBehaviour
{
    public Animation anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StopAnim()
    {
        if (anim != null)
        {
            anim.Stop();
        }
    }

    void StartAnim()
    {
        if (anim != null)
        {
            anim.Play();
        }
    }
}
