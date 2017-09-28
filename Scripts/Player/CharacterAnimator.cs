using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimator : MonoBehaviour {


    Animator animator;
    PlayerMovement playMove;


	void Start ()
    {
        animator = GetComponentInChildren<Animator>();
        playMove = GetComponent<PlayerMovement>();
	}
	
	void Update ()
    {
        float speedPercent = playMove.currentSpeed / playMove.maxSpeed;
        animator.SetFloat("speedPercent", speedPercent, 0.1f, Time.deltaTime);
	}
}
