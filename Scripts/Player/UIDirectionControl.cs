using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIDirectionControl : MonoBehaviour {


    //public GameObject player;

    //Vector3 position;

    public float camY;

	/*void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
	}

    void Update()
    {
        position = new Vector3(player.transform.position.x, 0.01f, player.transform.position.z);
        transform.position = position;       
    }*/

	void FixedUpdate ()
    {
        camY = Camera.main.transform.eulerAngles.y;
        transform.rotation = Quaternion.Euler(90, camY, 0);
    }
}
