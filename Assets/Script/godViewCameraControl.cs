using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Helper;

public class godViewCameraControl : MonoBehaviour
{
    public Transform followTarget;
    public float scrollSpeed = 6f;
    private float followDistance;
    private Vector3 followDirectoin;

    void Start()
    {
        followDirectoin = followTarget.position - transform.position;
        followDistance = followDirectoin.magnitude;
        followDirectoin.Normalize();
    }

    public void MoveCamera()
    {
        Vector2 scroll = Input.mouseScrollDelta;
        followDistance -= scroll.y * scrollSpeed;
        followDistance = Helper.Helper.GetRange(followDistance, 30f, 5f);
        transform.position = followTarget.position - followDirectoin * followDistance;
    }

    
    //void Update()
    //{
    //    transform.position = followTarget.position - followDirectoin * followDistance;
    //}
}
