using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    Animator animator;
    ThirdPersonMovement pmScript;
    float velocityZ = 0;
    float velocityX = 0;
    bool wpSheath;
    public bool attack;

    public GameObject sword;

    public float acceleration = 4f;
    public float deceleration = 2f;
    public float sprintSpeed = 12f;
    public float speed;




    //@TODO improve movement

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        pmScript = GetComponent<ThirdPersonMovement>();
        wpSheath = false;
        attack = false;
        speed = pmScript.speed;
    }

    // Update is called once per frame
    void Update()
    {
        // use Input from Player
        //bool forwardPressed = Input.GetKey("w");
        //bool leftPressed = Input.GetKey("a");
        //bool rightPressed = Input.GetKey("d");
        //bool backwardPressed = Input.GetKey("s");

        float horizontalMovement = Input.GetAxisRaw("Horizontal");
        float verticalMovement = Input.GetAxisRaw("Vertical");

        bool runPressed = Input.GetKey("left shift");


        Debug.Log("Horizontal Axis: " + horizontalMovement);
        Debug.Log("Vertical Axis: " + verticalMovement);


        // Forward Movement

        if (verticalMovement > 0 && velocityZ <= 0.5f && (!runPressed))
        {
            velocityZ += Time.deltaTime * acceleration;
            pmScript.speed = speed;

        }
        else if (verticalMovement == 0 && velocityZ > 0.0f && (!runPressed))
        {
            velocityZ -= Time.deltaTime * deceleration;
            pmScript.speed = speed;
        }

        else if ((verticalMovement > 0 && velocityZ <= 2f && (runPressed)))
        {
            velocityZ += Time.deltaTime * acceleration * 2;
            pmScript.speed = sprintSpeed;  

        }

        if (verticalMovement == 0 && velocityZ > 0.0f && (runPressed))
        {
            velocityZ -= Time.deltaTime * deceleration;
            pmScript.speed = sprintSpeed;



        }
        else if (verticalMovement == 0 && velocityZ < 0.0f && (runPressed))
        {
            velocityZ += Time.deltaTime * deceleration;
            pmScript.speed = sprintSpeed;

        }





        // Backward Movement

        if (verticalMovement < 0 && velocityZ > -0.5f && (!runPressed))
        {
            velocityZ -= Time.deltaTime * acceleration;
            pmScript.speed = speed;

        }

        else if (verticalMovement == 0 && velocityZ < -0.0f && (!runPressed)) 
        {
            velocityZ += Time.deltaTime * deceleration;
            pmScript.speed = speed;

        }

        else if (verticalMovement < 0 && velocityZ > -2f && (runPressed))
        {
            velocityZ -= Time.deltaTime * acceleration;
            pmScript.speed = sprintSpeed;

        }


        // Right Movement

        if (horizontalMovement > 0 && velocityX <= 0.5f && (!runPressed))
        {
            velocityX += Time.deltaTime * acceleration;
            pmScript.speed = speed;

        }

        else if (horizontalMovement == 0 && velocityX > 0.0f && (!runPressed))
        {
            velocityX -= Time.deltaTime * deceleration;
            pmScript.speed = speed;

        }

        else if (horizontalMovement > 0 && velocityX <= 2f && (runPressed)) 
        {
            velocityX += Time.deltaTime * acceleration;
            pmScript.speed = sprintSpeed;

        }

        // Left Movement

        if (horizontalMovement < 0 && velocityX > -0.5f && (!runPressed))
        {
            velocityX -= Time.deltaTime * acceleration;
            pmScript.speed = speed;

        }

        else if (horizontalMovement == 0 && velocityX < 0.0f && (!runPressed))
        {
            velocityX += Time.deltaTime * deceleration;
            pmScript.speed = speed;

        }

        else if (horizontalMovement < 0 && velocityX >= -2f && (runPressed)) 
        {
            velocityX -= Time.deltaTime * acceleration;
            pmScript.speed = sprintSpeed;

        }

        if (Input.GetKeyDown(KeyCode.R)) 
        {
            wpSheath = !wpSheath;
        }

        if (wpSheath)
        {
            sword.gameObject.SetActive(true);
        }
        else 
        {
            sword.gameObject.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && wpSheath) 
        {
            attack = true;
        }

        if (!Input.GetKeyDown(KeyCode.Mouse0)) 
        {
            attack = false;
        }
















        //if (forwardPressed && velocityZ < .5f && !runPressed) 
        //{
        //    velocityZ += Time.deltaTime * acceleration;
        //}

        //if (backwardPressed && velocityZ > -.5f && !runPressed) 
        //{
        //    velocityZ -= Time.deltaTime * acceleration;
        //}

        //if (leftPressed && velocityX > -.5f && !runPressed) 
        //{
        //    velocityX -= Time.deltaTime * acceleration;
        //}

        //if (rightPressed && velocityX < .5f && !runPressed) 
        //{
        //    velocityX += Time.deltaTime * acceleration;
        //}


        //// Decrease velocity to 0.0 if forward not pressed

        //if (!forwardPressed && velocityZ > 0.0f && !runPressed) 
        //{
        //    velocityZ -= Time.deltaTime * deceleration;
        //}

        //if ((!forwardPressed && !backwardPressed) && velocityZ > 0.0f && !runPressed) 
        //{
        //    velocityZ -= Time.deltaTime * deceleration;
        //}

        //if (!backwardPressed && velocityZ < 0.0f && !runPressed)
        //{
        //    velocityZ += Time.deltaTime * acceleration;
        //}


        //// increase velocityX

        //if (!leftPressed && velocityX < 0.0f && !runPressed) 
        //{
        //    velocityX += Time.deltaTime * deceleration;
        //}

        //if (!rightPressed && velocityX > 0.0f && !runPressed) 
        //{
        //    velocityX -= Time.deltaTime * deceleration;
        //}

        //if (!backwardPressed && velocityZ < 0.0f && !runPressed) 
        //{
        //    velocityZ += Time.deltaTime * deceleration;
        //}

        //if (!forwardPressed && velocityZ > 0.0f && !runPressed) 
        //{
        //    velocityZ += Time.deltaTime * deceleration;
        //}


        //// reset VelocityX
        //if (!leftPressed && !rightPressed && velocityX != 0.0f && (velocityX > -.05f && velocityX < 0.05f) && !runPressed) 
        //{
        //    velocityX = 0.0f;
        //}

        //if (!forwardPressed && !backwardPressed && velocityZ != 0.0f && (velocityZ > -.05f && velocityZ < 0.05f) && !runPressed) 
        //{
        //    velocityZ = 0.0f;
        // }




        animator.SetFloat("VelocityZ",velocityZ);
        animator.SetFloat("VelocityX", velocityX);
        animator.SetBool("wpSheath", wpSheath);
        animator.SetBool("Attack", attack);
        




    }
}
