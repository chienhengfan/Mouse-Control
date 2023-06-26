using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class main : MonoBehaviour
{
    private static main _singleton = null;
    public static main Singleton() { return _singleton; }
    public godViewCameraControl cameraControl;



    private void Awake()
    {
        _singleton = this;
    }
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
