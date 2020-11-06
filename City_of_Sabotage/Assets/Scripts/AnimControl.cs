using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimControl : MonoBehaviour
{
    public Animation anim;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animation>();
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StopAnim()
    {
        if (anim != null)
        {
            anim.Stop();
        }

        if (animator != null)
        {
            animator.speed = 0.0f;
        }
    }

    public void StartAnim()
    {
        if (anim != null)
        {
            anim.Play();
        }
        if (animator != null)
        {
            animator.speed = 1.0f;
        }
    }
}
