using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KickingManager : MonoBehaviour {

    GameObject ball;
    public float kickPower;
    bool _hasBall;

	void Start ()
    {
        ball = GameObject.Find("Ball");
	}
	
	
	void Update ()
    {
        _hasBall = GetComponent<PlayerManager>().hasBall;
        if (_hasBall && Input.GetButtonDown("Bbutton"))
        {
            BombKick();
        }
        
    }

    void BombKick()
    {      
        Vector3 dir = transform.forward;
        ball.GetComponent<Rigidbody>().AddForce(dir * kickPower, ForceMode.Impulse);
        StartCoroutine("WaitOneSecond");
    }

    void BallKicked()
    {
        _hasBall = false;
        ball.GetComponent<BallCollisionDetector>().ballTouched = false;
        ball.GetComponent<BallManager>().BallLoose();

    }

    IEnumerator WaitOneSecond()
    {
        yield return  new WaitForSeconds(1);
        BallKicked();
    }
        //
}
