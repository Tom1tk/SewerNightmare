using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScipt : MonoBehaviour
{
    public PauseMenu winUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Win!");
        winUI.win();
    }
}
