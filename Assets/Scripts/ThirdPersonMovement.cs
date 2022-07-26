using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    //Animator

     Animator animator;


    private CharacterController controller;
    public float speed = 6f;
    public float turnSmoothTime = .1f;
    public GameObject obj;

    // Gravity 
    public Transform groundCheck;
    public LayerMask groundMask;
    public Vector3 velocity;
    public float groundDistance = 0.4f;
    public float gravity = -9.81f;
    public bool isGrounded;
    // 


    public Transform cam;
    float turnSmoothVelocity;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }


        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");


        // Vector3 representing movement on the horizontal and vertical axis(.normalized) 

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;



        if (direction.magnitude >= .1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;

            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;


            controller.Move(moveDirection.normalized * speed * Time.deltaTime);
        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);


    }
}


 

