using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private CharacterController controller;
    public float movementSpeed = 12f;
    public Animator animator;
    public Transform groundCheck;
    public float gravity = -9.81f;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public float jumpForce = 15;

    private Vector3 velocity;
    private bool grounded = false;

    // Start is called before the first frame update
    void Start()
    {
        this.controller = this.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

        bool isKeyDown = Input.GetButton("Horizontal") || Input.GetButton("Vertical");


        grounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (grounded && velocity.y < 0)
            velocity.y = -2;

        if (grounded && velocity.y <= 0 && Input.GetButton("Jump"))
        {
            velocity.y = -gravity * Time.deltaTime + jumpForce;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * Time.deltaTime * movementSpeed);
        velocity.y += gravity * Time.deltaTime;
       
        controller.Move(velocity * Time.deltaTime);

       animator.SetBool("walkingUp", z > 0);
       animator.SetBool("walking", isKeyDown);
       

    }

    private Vector3 vecInPix = new Vector3();

    private Vector3 PixelPerfectClamp(Vector3 moveVector, float pixelsPerUnit) {
        vecInPix.Set(Mathf.RoundToInt(moveVector.x*pixelsPerUnit), 0,Mathf.RoundToInt(moveVector.z * pixelsPerUnit));

        return vecInPix / pixelsPerUnit;
    }

    private void OnDrawGizmos()
    {
        //Gizmos.DrawSphere(groundCheck.position, groundDistance);
    }
}
