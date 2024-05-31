using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    private Rigidbody2D rgbd2d;
    [HideInInspector] public Vector3 movementVector3;
    private Animate animate;

    [HideInInspector] public float LastHorizontalVector; 
    [HideInInspector] public float LastVerticalVector;

    private void Awake()
    {
        rgbd2d = GetComponent<Rigidbody2D>();
        movementVector3 = new Vector3();
        animate = GetComponent<Animate>();
    }
    void Update()
    {
        movementVector3.x = Input.GetAxisRaw("Horizontal");
        movementVector3.y = Input.GetAxisRaw("Vertical");

        if (movementVector3.x != 0)
        {
            LastHorizontalVector = movementVector3.x;
        }
        if (movementVector3.y != 0)
        {
            LastVerticalVector = movementVector3.y;
        }
        
        animate.horizontal = movementVector3.x;

        movementVector3 *= speed;
        rgbd2d.velocity = movementVector3;
    }  
}
