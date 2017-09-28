using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float maxSpeed;
    public float turnSpeed;
    public float sprintModifier;
    public float sprintModifierNorm;
    private float maxSprintSpeed;
    public float acceleration;
    public float currentSpeed;
    private float h;
    private float v;
    public float z;

    [HideInInspector]
    public bool isRunning = false;
    [HideInInspector]
    public bool isSprinting = false;

    public bool atPosOne = true;

    private CameraManager myCamera;

    Vector3 movement;
    Rigidbody playerRB;

    private int camNumAdjust;


    void Awake()
    {
        playerRB = GetComponent<Rigidbody>();      
        sprintModifierNorm = sprintModifier;
        myCamera = GameObject.Find("Main Camera").GetComponent<CameraManager>();
        maxSprintSpeed = maxSpeed * sprintModifier;
        currentSpeed = 0f;
    }

    void Update()
    {
        RunCheck(currentSpeed);
        SprintCheck();

        z = Mathf.Clamp01(Mathf.Sqrt(h * h + v * v));

        isRunning = RunCheck(currentSpeed);
        isSprinting = SprintCheck();

        if (myCamera.atPosOne == true)
        {
            atPosOne = true;
        }
        else
        {
            atPosOne = false;
        }

    }

    void FixedUpdate()
    {
        if (atPosOne)
        {
            h = Input.GetAxis("Horizontal");
            v = Input.GetAxis("Vertical");
        }
        else
        {
            h = Input.GetAxis("Horizontal") * -1;
            v = Input.GetAxis("Vertical") * -1;
        }

        Sprint();
        Move(h, v);
    }

    void Move(float h , float v)
    {


        if (h != 0f || v != 0f)
        {
            movement.Set(h * maxSpeed * Time.deltaTime, 0f, v * maxSpeed * Time.deltaTime);
            playerRB.MovePosition(transform.position + movement);
            Turn(h, v);

        }
        else
        {
            currentSpeed = 0f;
        }
    }

    void Turn(float h, float v)
    {
        Vector3 targetDirection = new Vector3(h, 0 ,v);
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);
        Quaternion newRotation = Quaternion.Lerp(playerRB.rotation, targetRotation, turnSpeed * Time.deltaTime);
        playerRB.MoveRotation(newRotation);
    }

    public void Sprint()
    {
        bool sprinting;
        if (Input.GetAxisRaw("Rtrigger") < 0)
        {
            sprinting = true;
        }
        else
        {
            sprinting = false;
        }

        if (sprinting == true)
        {
            currentSpeed = Mathf.Lerp(currentSpeed, maxSprintSpeed, acceleration * Time.deltaTime * z);
        }
        else
        {
            currentSpeed = Mathf.Lerp(currentSpeed, maxSpeed, acceleration * Time.deltaTime * z);
        }
    }

    public bool RunCheck(float speed)
    {
        if (speed >= 1)
        {
            return true;
        }
        else
        {
            return false;  
        }
    }

    public bool SprintCheck()
    {
        if (RunCheck(currentSpeed) == true && Input.GetAxisRaw("Rtrigger") < 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
