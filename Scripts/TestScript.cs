using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour {


    void Update()
    {
        if (Input.GetButtonDown("Abutton"))
            Debug.Log("A");
        if (Input.GetButtonDown("Bbutton"))
            Debug.Log("B");
        if (Input.GetButtonDown("Xbutton"))
            Debug.Log("X");
        if (Input.GetButtonDown("Ybutton"))
            Debug.Log("Y");
        if (Input.GetButtonDown("Rbumper"))
            Debug.Log("Rb");
        if (Input.GetButtonDown("Lbumper"))
            Debug.Log("Lb");
        if (Input.GetAxisRaw("Rtrigger") < 0)
            Debug.Log("Rt");
        if (Input.GetAxisRaw("Ltrigger") > 0)
            Debug.Log("Lt");
    }


}
