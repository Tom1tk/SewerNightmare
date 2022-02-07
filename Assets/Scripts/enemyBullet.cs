using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBullet : MonoBehaviour
{
    public float speed = 10f;
    public float damage = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        RaycastGun player = other.GetComponent<RaycastGun>();
        if(player != null)
        {
            player.recieveDamage(damage);
            Debug.Log("player is hit");
        }

        Destroy(this.gameObject);
    }
}
