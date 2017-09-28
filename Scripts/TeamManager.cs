using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamManager : MonoBehaviour {

    public GameObject ball; //points to the ball gameObject
    public GameObject oppositionTeam; //points to the opposing team gamObject

    public Transform controlledPlayer; // the player being user-controlled
    public Transform playerClosestToBall; // the player closest to the ball
    public Transform passTargetLeft; //player to receive a potential pass to the left
    public Transform passTargetRight;//player to receive a potential pass to the right
    public Transform receivingPlayer; //player receiving the ball from a pass
    public Transform ballCarrier; //player with the ball

    public bool isAttacking; // is the team in attack and in possession
    public bool isDefending; // is the team defending and the opposition in possession

    public Transform[] players; //array containing all the tranforms for the players of this team

    


}
