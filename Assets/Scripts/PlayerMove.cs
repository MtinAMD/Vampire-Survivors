using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    private Rigidbody2D rgbd2d;
    private Vector3 movementVector3;
    private Animate animate;

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

        animate.horizontal = movementVector3.x;

        movementVector3 *= speed;
        rgbd2d.velocity = movementVector3;
    }  
}
