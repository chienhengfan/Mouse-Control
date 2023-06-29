using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPSControl : MonoBehaviour
{
    public TPSTarget lookAtTPS;
    public float followDistance;
    public Transform camera;
    private Vector3 horizontalDirection;
    private Vector3 verticalDirection;
    public float cameraSensitive = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        horizontalDirection = transform.forward;
        verticalDirection = transform.up;
    }

    // Update is called once per frame
    void Update()
    {
        float MouseX = Input.GetAxis("Mouse X");
        float MouseY = -Input.GetAxis("Mouse Y");

        // horizontal rotate
        horizontalDirection = Quaternion.Euler(0, MouseX * cameraSensitive, 0) * horizontalDirection;
        // vertical rotate
        verticalDirection = Quaternion.Euler(MouseY, 0, 0) * verticalDirection;


        lookAtTPS.UpdateTarget();
        Vector3 cameraPosition = lookAtTPS.transform.position - horizontalDirection * followDistance;
        camera.position = cameraPosition;
        camera.LookAt(lookAtTPS.transform.position);

    }
}
