using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour {

    public bool hasBall;

    public Image possessionIndicator;

    GameObject ball;

    void Start ()
    {
        ball = GameObject.Find("Ball");
        possessionIndicator.GetComponent<Image>().enabled = false;
    }


    void Update()
    {
        if (ball.GetComponent<BallCollisionDetector>().ballTouched == true)
        {
            hasBall = true;
            possessionIndicator.GetComponent<Image>().enabled = true;
        }
        else
        {
            hasBall = false;
            possessionIndicator.GetComponent<Image>().enabled = false;
        }
    }


}
