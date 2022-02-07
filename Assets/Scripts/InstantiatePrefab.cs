using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiatePrefab : MonoBehaviour
{

    //public Transform prefab;
    public Rigidbody projectile;
    public Transform gunBarrel;

    // Update is called once per frame
    void Update()
    {
        if (PauseMenu.GamePaused == true)
        {
            return;
        }
        

        if (Input.GetButtonDown("Fire1"))
        {
            Rigidbody projectileInstance;
            projectileInstance = Instantiate(projectile, gunBarrel.position, gunBarrel.rotation) as Rigidbody;
            projectileInstance.AddForce(gunBarrel.up * 1000f);
        }        
    }
}
