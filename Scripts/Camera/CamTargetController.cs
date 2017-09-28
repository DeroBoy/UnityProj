using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamTargetController : MonoBehaviour {

    public Transform camTarget;
    public Transform posOne;
    public Transform posTwo;

    GameObject camPosOne;
    GameObject camPosTwo;
    GameObject followTarget;

    float minX = -25f;
    float maxX = 25f;
    float minZOne = -74f;
    float maxZOne = 28f;
    float minZTwo = -28f;
    float maxZTwo = 74f;

    Vector3 cameraTarget;
    Vector3 camPosOnePosition;
    public Vector3 camPosOneOffset;
    Vector3 camPosTwoPosition;
    public Vector3 camPosTwoOffset;

    void Start()
    {
        followTarget = GameObject.FindWithTag("Player");
        cameraTarget = followTarget.transform.position;
        camPosOnePosition = posOne.transform.position;
        camPosTwoPosition = posTwo.transform.position;
    }

    void FixedUpdate()
    {
        cameraTarget = followTarget.transform.position; //camera target position update
        cameraTarget = new Vector3(Mathf.Clamp(cameraTarget.x, minX, maxX), 0, cameraTarget.z);
        camTarget.transform.position = cameraTarget;

        camPosOnePosition = camTarget.position + camPosOneOffset;
        camPosOnePosition = new Vector3(Mathf.Clamp(camPosOnePosition.x, minX, maxX), camPosOnePosition.y, Mathf.Clamp(camPosOnePosition.z, minZOne, maxZOne));
        posOne.transform.position = camPosOnePosition;

        camPosTwoPosition = camTarget.position + camPosTwoOffset;
        camPosTwoPosition = new Vector3(Mathf.Clamp(camPosTwoPosition.x, minX, maxX), camPosTwoPosition.y, Mathf.Clamp(camPosTwoPosition.z, minZTwo, maxZTwo));
        posTwo.transform.position = camPosTwoPosition;

    }
}
