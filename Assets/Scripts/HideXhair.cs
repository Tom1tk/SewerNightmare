using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideXhair : MonoBehaviour
{
    public GameObject XhairUI;

    // Start is called before the first frame update
    void Start()
    {
        XhairUI.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseMenu.GamePaused == true)
        {
            XhairUI.SetActive(false); ;
        }
        else
        {
            XhairUI.SetActive(true);
        }

    }
}
