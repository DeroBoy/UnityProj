using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {

    
    public float tripTime;
    public float smoothing;
    public float camHeight = 10f;

    float minX = -25f;
    float maxX = 25f;
    float minZOne = -74f;
    float maxZOne = 28f;
    float minZTwo = -28f;
    float maxZTwo = 74f;

    public Vector3 velocity = Vector3.zero;

    public Transform target;
    public Transform posOne;
    public Transform posTwo;

    Transform currentPos;
    Transform targetPos;

    public bool atPosOne;

    float startTime;

    Vector3 position;
    Vector3 direction;

    Vector3 centrePoint;
    Vector3 startRelCentre;
    Vector3 endRelCentre;
    Vector3 destination;



    public bool camSpin = false;


    void Start ()
    {
        transform.position = posOne.position;
        atPosOne = true;
        currentPos = posOne;
        position = transform.position;
        direction = Vector3.right;
    }
	

	void Update ()
    {
        if (Input.GetButtonDown("Abutton") && !camSpin)
        {
            if (transform.position.x <= 0)
            {
                direction = Vector3.right;
            }
            else if (transform.position.x > 0)
            {
                direction = Vector3.left;
            }

            camSpin = true;
            startTime = Time.time;
            Time.timeScale = 0.05f;
            Time.fixedDeltaTime = 0.02f * Time.timeScale;
        }

        if (camSpin)
        {
            GetCentre();
            CamSwitch();
        }       
    }

    void FixedUpdate()
    {
        if (atPosOne)
        {
            currentPos = posOne;
            targetPos = posTwo;
            destination = targetPos.position;
        }
        else
        {
            currentPos = posTwo;
            targetPos = posOne;
            destination = targetPos.position;
        }

        if (!camSpin)
        {
            if (atPosOne)
            {
                position = Vector3.SmoothDamp(transform.position, currentPos.position, ref velocity, smoothing);
                position = new Vector3(Mathf.Clamp(position.x, minX, maxX), camHeight, Mathf.Clamp(position.z, minZOne, maxZOne));
                transform.position = position;
                transform.rotation = Quaternion.Euler(30, 0, 0);
            }
            else
            {
                position = Vector3.SmoothDamp(transform.position, currentPos.position, ref velocity, smoothing);
                position = new Vector3(Mathf.Clamp(position.x, minX, maxX), camHeight, Mathf.Clamp(position.z, minZTwo, maxZTwo));
                transform.position = position;
                transform.rotation = Quaternion.Euler(30, 180, 0);
            }

            //transform.LookAt(target.position);    //dynamic look-at camera option//

        }     
    }

    public void GetCentre()
    {       
        centrePoint = (posOne.position + posTwo.position) * 0.5f;
        centrePoint -= direction;
        startRelCentre = currentPos.position - centrePoint;
        endRelCentre = targetPos.position - centrePoint;
    }

    public void CamSwitch()
    {
        float fracComplete = (Time.time - startTime) / tripTime * 1 / Time.timeScale;
        transform.position = Vector3.Slerp(startRelCentre, endRelCentre, fracComplete);
        transform.position += centrePoint;
        transform.LookAt(target.position);
        
        if (Vector3.Distance(transform.position, destination) < 0.01f)
        {
            atPosOne = !atPosOne;
            camSpin = !camSpin;           
            Time.timeScale = 1;
            /*if (atPosOne)
            {
                transform.rotation = Quaternion.Euler (30, 0, 0);
            }
            else
            {
                transform.rotation = Quaternion.Euler(30, 180, 0);
            }*/
        }
    }
}
