using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollisionDetector : MonoBehaviour {

    public bool ballTouched;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            ballTouched = true;
        }
        else
        {
            ballTouched = false;
        }
    }
}
