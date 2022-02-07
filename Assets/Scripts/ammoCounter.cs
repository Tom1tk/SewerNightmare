using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ammoCounter : MonoBehaviour
{
    public TextMeshProUGUI current;
    public TextMeshProUGUI Max;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateUI(int currentAmmo, int maxAmmo)
    {
        if(current != null)
        {
            current.text = currentAmmo.ToString();
        }

        if (Max != null)
        {
            Max.text = maxAmmo.ToString();
        }
    }
}
