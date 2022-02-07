using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public KeyManager KMRef;
    public GameObject door;
    public int doorNum;
    
    void Start()
    {
        gameObject.SetActive(true);
    }

    void OnTriggerStay(Collider other)
    {
        if(Input.GetKey(KeyCode.E))
        {
            bool unlocked = KMRef.doorOpen(doorNum);
            Debug.Log("door interacted: " + doorNum);
            if(unlocked)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
