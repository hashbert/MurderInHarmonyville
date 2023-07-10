    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueAnimation : MonoBehaviour
{

    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("t"))
        {
            animator.Play("Thinking");
        }
        if (Input.GetKey("p"))
        {
            animator.Play("Talking");
        }
        if (Input.GetKey("o"))
        {
            animator.Play("Argue");
        }
        if (Input.GetKey("m"))
        {
            animator.Play("AngryPoint");
        }
        if (Input.GetKey("k"))
        {
            animator.Play("Angry");
        }

    }
}
