using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winDoor : MonoBehaviour
{
    public GameObject winScreen;
void OnTriggerStay(Collider other)
    {
        if(Input.GetKey(KeyCode.E))
        {
            winScreen.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
