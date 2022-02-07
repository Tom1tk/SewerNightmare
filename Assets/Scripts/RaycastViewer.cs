using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastViewer : MonoBehaviour
{
    public float range = 50f;
    public Camera fpsCamera;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay (fpsCamera.transform.position, fpsCamera.transform.forward * range, Color.green);
    }
}
