using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodViewControl : MonoBehaviour
{
    public float moveSpeed = 2.0f;
    public LayerMask iLayerMask;
    private Camera cam;

    
    void Start()
    {
        cam = Camera.main;
    }

    public void MoveForward(Vector3 direction, float moveAFrame)
    {
        direction.y = 0f;
        transform.forward = direction;

        Vector3 moveTarget = transform.position + direction * moveAFrame;
        Vector3 moveTargetUp = moveTarget;
        moveTargetUp.y += 1.0f;

        RaycastHit rh = new RaycastHit();
        if(Physics.Raycast(moveTargetUp, -Vector3.up, out rh, 5f, iLayerMask))
        {
            if(transform.position.y - rh.point.y < 0.5)
            {
                transform.position = rh.point;
            }         
            Debug.Log("hit");
        }
        else { Debug.Log("no hit"); }
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePosition = Input.mousePosition;
            Ray mouseClickRay = cam.ScreenPointToRay(mousePosition);
            RaycastHit rayHitByMouse = new RaycastHit();

            if (Physics.Raycast(mouseClickRay, out rayHitByMouse, 1000f, iLayerMask))
            {
                Vector3 direction = rayHitByMouse.point - transform.position;
                direction.y = 0f;
                float moveAFrame = moveSpeed * Time.deltaTime;

                if (direction.magnitude < moveAFrame)
                {
                    transform.position = rayHitByMouse.point;
                }
                else
                {
                    direction.Normalize();
                    MoveForward(direction, moveAFrame);
                }
            }

            
        }
        main.Singleton().cameraControl.MoveCamera();
    }
}
