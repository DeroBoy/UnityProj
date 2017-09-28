using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour {

    GameObject indicator;
    GameObject ball;

    BallCollisionDetector ballCol;

    public Transform carryPosition;

    bool ballCarried;
    bool ballLoose;
    float ballHeight;
    Vector3 indicatorPos;

    void Start()
    {
        ball = GameObject.Find("Ball");
        indicator = GameObject.Find("BallIndicator");
        ballCol = GetComponent<BallCollisionDetector>();
    }

    void Update()
    {
        ballHeight = ball.transform.position.y;
        indicator.transform.rotation = Quaternion.Euler(90, 0, 0);

        if (ballCol.ballTouched == true)
        {
            BallCarried();
        }
        else
        {
            BallLoose();
        }
        
        
    }
	
	void FixedUpdate ()
    {
        IconScaler(ballHeight);
    }
    void LateUpdate()
    {
        indicatorPos = new Vector3(ball.transform.position.x, 0.01f, ball.transform.position.z);
        indicator.transform.position = indicatorPos;
    }

    void IconScaler(float ballHeight)
    {
        float ballH = ballHeight / 2f;
        float indiScale = Mathf.Clamp(ballH, 1, 10);
        Vector3 scale = new Vector3(indiScale, indiScale, indiScale);
        indicator.transform.localScale = scale;
    }

    public void BallCarried()
    {
        ball.transform.position = carryPosition.transform.position;
        ball.transform.rotation = carryPosition.transform.rotation;
        ball.GetComponent<TrailRenderer>().enabled = false;
        indicator.GetComponent<MeshRenderer>().enabled = false;
        ball.GetComponent<Rigidbody>().freezeRotation = true;
        ball.GetComponent<Rigidbody>().detectCollisions = false;
    }

    public void BallLoose()
    {
        ball.GetComponent<TrailRenderer>().enabled = true;
        indicator.GetComponent<MeshRenderer>().enabled = true;
        ball.GetComponent<Rigidbody>().freezeRotation = false;
        ball.GetComponent<Rigidbody>().detectCollisions = true;
    }
}
