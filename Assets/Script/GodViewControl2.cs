using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodViewControl2 : MonoBehaviour
{
    public float moveSpeed = 2.0f;
    public LayerMask iLayerMask;
    private Camera cam;
    private CharacterController characterControl;


    void Start()
    {
        cam = Camera.main;
        characterControl = GetComponent<CharacterController>();
    }

    public void MoveForward(Vector3 direction, float moveAFrame)
    {
        float speedSimpleMove = moveAFrame / Time.deltaTime;
        //simpleMove will multiply Time.deltatime, thus not do it again 
        characterControl.SimpleMove(direction * speedSimpleMove);
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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 jumpDirection = Vector3.up;
            transform.position += jumpDirection * 10f;
        }
        main.Singleton().cameraControl.MoveCamera();
    }
}