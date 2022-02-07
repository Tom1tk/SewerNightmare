using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour
{
    public bool keyA, keyB, keyC;
    public AudioClip locked;
    public AudioClip unlock;
    public AudioClip pickupSound;
    public AudioSource AS;

    // Start is called before the first frame update
    void Start()
    {
        keyA = false;
        keyB = false;
        keyC = false;
    }

    public void keyCollected(int key)
    {
        switch(key)
        {
            case 1:
                keyA = true;
                AS.PlayOneShot(pickupSound);
                return;
            case 2:
                keyB = true;
                AS.PlayOneShot(pickupSound);
                return;
            case 3:
                keyC = true;
                AS.PlayOneShot(pickupSound);
                return;
            default:
                return;
        }
    }

    public bool doorOpen(int door)
    {
        switch(door)
        {
            case 1:
                if(keyA == true)
                {
                    AS.PlayOneShot(unlock);
                    return true;
                }else{
                    AS.PlayOneShot(locked);
                    return false;
                }
            case 2:
                if(keyB == true)
                {
                    AS.PlayOneShot(unlock);
                    return true;
                }else{
                    AS.PlayOneShot(locked);
                    return false;
                }
            case 3:
                if(keyC == true)
                {
                    AS.PlayOneShot(unlock);
                    return true;
                }else{
                    AS.PlayOneShot(locked);
                    return false;
                }
            default:
                AS.PlayOneShot(locked);
                return false;
        }
    }
}
