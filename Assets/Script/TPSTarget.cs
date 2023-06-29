using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPSTarget : MonoBehaviour
{
    public Transform TargetTo;
    public float Hieght;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void UpdateTarget()
    {
        transform.position = TargetTo.position + Vector3.up * Hieght;
    }
}
