using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keys : MonoBehaviour
{
    public KeyManager KMRef;
    public GameObject key;
    public int keyNum;

    void Start()
    {
        gameObject.SetActive(true);
    }

    void OnTriggerStay(Collider other)
    {
        if(Input.GetKey(KeyCode.E))
        {
            KMRef.keyCollected(keyNum);
            Debug.Log("Key collected: " + keyNum);
            gameObject.SetActive(false);
        }
    }
}
