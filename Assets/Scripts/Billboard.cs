using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    public Camera FPScam;
    public Transform FPScamera;

    // Update is called once per frame
    void LateUpdate()
    {
        FPScam = FindObjectOfType<Camera>();
        //Camera mainCam = GameObject.Find("MainCamera").GetComponent<Camera>();
        transform.LookAt(transform.position + FPScam.transform.forward);
    }
}
