using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("a"))
        {
            animator.SetBool("isLeft", true);
        }
        if (Input.GetKey("d"))
        {
            animator.SetBool("isRight", true);
        }
        if (!Input.GetKey("a"))
        {
            animator.SetBool("isLeft", false);
        }
        if (!Input.GetKey("d"))
        {
            animator.SetBool("isRight", false);
        }
    }
}
