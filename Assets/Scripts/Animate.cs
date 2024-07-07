using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animate : MonoBehaviour
{
    private Animator animator;

    public float horizontal;

    private void Update()
    {
        animator.SetFloat("Horizontal",horizontal);
    }

    public void SetAnimate(GameObject animGameObject)
    {
        animator = animGameObject.GetComponent<Animator>();
    }
}
